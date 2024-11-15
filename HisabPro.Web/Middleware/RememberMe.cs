﻿using Hisab.CryptoService;
using HisabPro.Constants;
using HisabPro.Repository.Interfaces;
using HisabPro.Services;

namespace HisabPro.Web.Middleware
{
    public class RememberMe(RequestDelegate next, AuthService authService, IServiceProvider serviceProvider, IConfiguration configuartion)
    {
        private readonly RequestDelegate _next = next;
        private readonly AuthService _authService = authService;
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        public IConfiguration Configuartion { get; } = configuartion;

        public async Task InvokeAsync(HttpContext context)
        {
            using var scope = _serviceProvider.CreateScope();
            var _userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
            //Check if the request requires authentication using JWT token
            //if (context.User.Identity.IsAuthenticated)
            //{
            //    
            //    Handle token validation here
            //     Example: Check for token expiration
            //    var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            //    if (string.IsNullOrEmpty(token) || !ValidateToken(token))
            //    {
            //        context.Response.Redirect("/login"); // Redirect to login if token is invalid
            //        return;
            //    }
            //}
            if (context.User.Identity != null)
            {
                if (!context.User.Identity.IsAuthenticated && context.Request.Cookies.TryGetValue(AppConst.Cookies.RememberMe, out var encryptedUserId))
                {
                    var userId = EncryptionHelper.Decrypt(encryptedUserId);
                    if (int.TryParse(userId, out var id))
                    {
                        var user = await _userRepository.GetUser(u => u.Id == id);
                        if (user != null)
                        {
                            await _authService.SignInUser(user);
                        }
                    }
                }
            }
            await _next(context);
        }

        //private bool ValidateToken(string token)
        //{
        //    try
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var key = Encoding.ASCII.GetBytes(_configuartion[AppConst.Configs.JwtKey]);
        //        tokenHandler.ValidateToken(token, new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidIssuer = _configuartion[AppConst.Configs.JwtIssuer],
        //            ValidAudience = _configuartion[AppConst.Configs.JwtAudience],
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateLifetime = true // Validate token expiration
        //        }, out SecurityToken validatedToken);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
