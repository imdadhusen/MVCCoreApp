using AutoMapper;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Interfaces;
using HisabPro.Constants;
using HisabPro.Services.Helper;
using System.Security.Cryptography;
using HisabPro.Common;
using Microsoft.Extensions.Options;

namespace HisabPro.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly UpdateRepository<User, UserRes> _updateRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;
        private readonly AppSettings _appSettings;

        public UserService(UpdateRepository<User, UserRes> updateRepo, IMapper mapper, IRepository<User> userRepo, EmailService emailService, IOptions<AppSettings> appSettings)
        {
            _updateRepo = updateRepo;
            _mapper = mapper;
            _userRepo = userRepo;
            _emailService = emailService;
            _appSettings = appSettings.Value;
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
            return new ResponseDTO<List<UserRes>>(System.Net.HttpStatusCode.OK, AppConst.ApiMessage.DataRetrived, map);
        }
        public async Task<PageDataRes<UserRes>> PageData(LoadDataRequest request)
        {
            var data = _userRepo.GetPageDataWithChildrenAsync("Creator", "Modifier");
            data = data.ApplyDynamicFilters(request.Filters);
            data = PageDataHelper.ApplySort(data, request.PageData);
            var pagedData = await PageDataHelper.ApplyPage<User, UserRes>(data, request.PageData, _mapper);
            return pagedData;
        }

        public async Task<ResponseDTO<UserRes>> SaveAsync(SaveUserReq req, string activationLink)
        {
            var map = _mapper.Map<User>(req);
            // Set activation link and expiry when user is created
            if (!req.Id.HasValue)
            {
                map.IsActive = false;
                map.Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                map.TokenExpiry = DateTime.UtcNow.AddHours(_appSettings.User.PasswordResetExpiryHours);
            }
            var result = await _updateRepo.SaveAsync(map, req.Email, req.Id);

            // Send user activation link in email when user is created
            if (result != null && !req.Id.HasValue)
            {
                string link = activationLink.Replace("000", map.Token);
                await _emailService.SendEmailAsync(EnumEmailTypes.ActivateAccount, req.Email, new { ActivationLink = link }); //new { FirstName = firstName, LastName = lastName }
            }
            return new ResponseDTO<UserRes>(System.Net.HttpStatusCode.OK, AppConst.ApiMessage.Save, result);
        }

        public async Task<ResponseDTO<bool>> DeleteAsync(int id)
        {
            var result = await _userRepo.DeleteAsync(id);
            if (result)
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.OK, AppConst.ApiMessage.Delete, result);
            }
            else
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.BadRequest, AppConst.ApiMessage.NotFound, result);
            }
        }

        //public async Task<List<IdNameRes>> GetAccountsAsync()
        //{
        //    return await _accountRepo.GetAllAsync(a => new IdNameRes { Id = a.Id.ToString(), Name = a.Name });
        //}
    }
}
