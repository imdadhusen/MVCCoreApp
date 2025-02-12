using AutoMapper;
using Hisab.Tools.PasswordService;
using HisabPro.Common;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Repository;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Helper;
using HisabPro.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using User = HisabPro.Entities.Models.User;

namespace HisabPro.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly UpdateRepository<User, UserRes> _updateRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;
        private readonly AppSettings _appSettings;
        private readonly ISharedViewLocalizer _localizer;

        public UserService(UpdateRepository<User, UserRes> updateRepo, IMapper mapper, IRepository<User> userRepo, EmailService emailService, IOptions<AppSettings> appSettings, ISharedViewLocalizer localizer)
        {
            _updateRepo = updateRepo;
            _mapper = mapper;
            _userRepo = userRepo;
            _emailService = emailService;
            _appSettings = appSettings.Value;
            _localizer = localizer;
        }

        public async Task<SaveUserReq> GetByIdAsync(int id)
        {
            var account = await _userRepo.GetByIdAsync(id);
            var map = _mapper.Map<SaveUserReq>(account);
            return map;
        }

        public async Task<ResponseDTO<List<UserRes>>> GetAll()
        {
            var users = await _userRepo.GetAllWithChildrenAsync("Creator", "Modifier");
            var map = _mapper.Map<List<UserRes>>(users);
            return new ResponseDTO<List<UserRes>>(System.Net.HttpStatusCode.OK, _localizer.Get(ResourceKey.LabelApiDataRetrived), map);
        }
        public async Task<PageDataRes<UserRes>> PageData(LoadDataRequest request)
        {
            var data = _userRepo.GetPageDataWithChildrenAsync("Creator", "Modifier");
            data = data.ApplyDynamicFilters(request.Filters);
            data = PageDataHelper.ApplySort(data, request.PageData);
            var pagedData = await PageDataHelper.ApplyPage<User, UserRes>(data, request.PageData, _mapper);
            return pagedData;
        }

        public async Task<ResponseDTO<UserRes>> SaveAsync(SaveUserReq req, string activationLink, bool useFallback = false)
        {
            var map = _mapper.Map<User>(req);
            // Set activation link and expiry when user is created
            if (!req.Id.HasValue)
            {
                map.IsActive = false;
                map.Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                map.TokenExpiry = DateTime.UtcNow.AddHours(_appSettings.User.PasswordResetExpiryHours);
            }
            var result = await _updateRepo.SaveAsync(map, req.Email, req.Id, useFallback);

            // Send user activation link in email when user is created
            if (result != null && !req.Id.HasValue)
            {
                string link = activationLink.Replace("000", map.Token);
                await _emailService.SendEmailAsync(EnumEmailTypes.ActivateAccount, req.Email, new { ActivationLink = link }); //new { FirstName = firstName, LastName = lastName }
            }
            return new ResponseDTO<UserRes>(System.Net.HttpStatusCode.OK, _localizer.Get(ResourceKey.LabelApiSave), result);
        }

        public async Task<ResponseDTO<bool>> DeleteAsync(int id)
        {
            var result = await _userRepo.DeleteAsync(id);
            if (result)
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.OK, _localizer.Get(ResourceKey.LabelApiDelete), result);
            }
            else
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.BadRequest, _localizer.Get(ResourceKey.LabelApiNotFound), result);
            }
        }

        public async Task<ResponseDTO<UserRes?>> ActivateUser(string email, string token)
        {
            var user = await _userRepo.GetAll()
                .Where(u => u.Email == email && u.Token == token && u.IsActive == false)
                .FirstOrDefaultAsync();
            if (user == null || user.TokenExpiry < DateTime.UtcNow)
            {
                return new ResponseDTO<UserRes?>(System.Net.HttpStatusCode.OK, _localizer.Get(ResourceKey.LabelActivationFailedTitle), null);
            }
            else
            {
                user.IsActive = true;
                user.Token = null;
                user.TokenExpiry = null;
                var savedUser = await _userRepo.SaveAsync(user);
                var map = _mapper.Map<UserRes>(savedUser);
                return new ResponseDTO<UserRes?>(System.Net.HttpStatusCode.OK, _localizer.Get(ResourceKey.LabelApiUserActivate), map);
            }
        }

        public async Task<ResponseDTO<bool>> ChangePassword(SetPasswordReq request)
        {
            if (request.UserId == null)
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.BadRequest, _localizer.Get(ResourceKey.LabelApiUserNotFound), false);
            }
            var user = await _userRepo.GetByIdAsync(request.UserId);

            if (user == null)
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.BadRequest, _localizer.Get(ResourceKey.LabelApiUserNotFound), false);
            }
            //var map = new LoginRes()
            //{
            //    Id = user.Id,
            //    Email = user.Email,
            //    PasswordHash = user.PasswordHash,
            //    PasswordSalt = user.PasswordSalt,
            //    Name = user.Name,
            //    UserRole = user.UserRole,
            //    PasswordChangedOn = DateHelper.GetUTC,
            //    MustChangePassword = false
            //};
            //await _authService.SignInUser(map);
            // Check if the new password is the same as the old one
            if (!string.IsNullOrEmpty(user.PasswordHash) && !string.IsNullOrEmpty(user.PasswordSalt))
            {
                bool isUnique = Argon2PasswordHelper.IsNewPasswordUnique(request.NewPassword, user.PasswordHash, user.PasswordSalt);
                if (!isUnique)
                {
                    return new ResponseDTO<bool>(System.Net.HttpStatusCode.BadRequest, _localizer.Get(ResourceKey.LabelApiPasswordShouldNotMatchCurrent), false);
                }
                else
                {
                    // Generate a new salt and hash for the new password
                    string passwordSalt;
                    string passwordHash = Argon2PasswordHelper.CreatePasswordHash(request.NewPassword, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    await _userRepo.SaveAsync(user, true);
                }
            }
            return new ResponseDTO<bool>(System.Net.HttpStatusCode.OK, _localizer.Get(ResourceKey.LabelApiPasswordUpdated), true);
        }
    }
}
