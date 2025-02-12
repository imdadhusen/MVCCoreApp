using AutoMapper;
using Hisab.Tools.PasswordService;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HisabPro.Repository.Implements
{
    public class UserRepository(ApplicationDbContext context, IMapper mapper, AppSettings appSettings, ISharedViewLocalizer localizer) : IUserRepository
    {
        public readonly ApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly AppSettings _appSettings = appSettings;
        private readonly ISharedViewLocalizer _localizer = localizer;

        public async Task<User?> GetUser(Expression<Func<User, bool>> predicate)
        {
            User? data;
            if (predicate != null)
            {
                data = await _context.Users.FirstOrDefaultAsync(predicate);
            }
            else
            {
                data = await _context.Users.FirstOrDefaultAsync();
            }
            return data;
            //return _mapper.Map<User, LoginRes>(data);
        }


        public async Task<ResponseDTO<LoginRes?>> Authenticate(string email, string password)
        {
            var response = new ResponseDTO<LoginRes>(System.Net.HttpStatusCode.Unauthorized, "", null);
            var user = await GetUser(u => u.Email == email);
            if (user == null)
            {
                response.Message = _localizer.Get(ResourceKey.LabelEmailNotFound);
            }
            else if (user.IsLockedOut)
            {
                response.Message = _localizer.Get(ResourceKey.LabelApiAccountLocked);
            }
            else
            {
                var isPasswordValid = Argon2PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);

                if (!isPasswordValid)
                {
                    // Failed login attempt
                    user.FailedLoginAttempts++;
                    if (user.FailedLoginAttempts >= _appSettings.User.MaxLoginAttempts)
                    {
                        // Lock the account after 3 failed attempts
                        response.Message = _localizer.Get(ResourceKey.LabelApiAccountLocked);
                        user.LockoutEnd = DateTime.UtcNow.AddMinutes(_appSettings.User.AccountLockedForMins); // Lock for 15 minutes
                    }
                    var attemptRemain = _appSettings.User.MaxLoginAttempts - user.FailedLoginAttempts;
                    if (attemptRemain > 0)
                    {
                        response.Message = string.Format(_localizer.Get(ResourceKey.LabelApiInvalidAttempt), attemptRemain);
                    }
                    else
                    {
                        response.Message = string.Format(_localizer.Get(ResourceKey.LabelApiAccountLockedWithUnlockTime), _appSettings.User.AccountLockedForMins);
                    }

                    _context.Users.Update(user);
                    await _context.SaveChangesWithAuditAsync(useFallback: true);
                }
                else
                {
                    // Successful login
                    user.FailedLoginAttempts = 0; // Reset failed attempts
                    _context.Users.Update(user);
                    await _context.SaveChangesWithAuditAsync(useFallback: true);

                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    response.Message = _localizer.Get(ResourceKey.LabelApiLoginSuccess);
                    response.Response = _mapper.Map<User, LoginRes>(user);
                }
            }
            return response;
        }
    }
}
