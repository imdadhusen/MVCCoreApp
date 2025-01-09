using AutoMapper;
using Hisab.CryptoService;
using HisabPro.Constants;
using HisabPro.DTO.Response;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Implements;
using HisabPro.Services.Interfaces;

namespace HisabPro.Web.Middleware
{
    public class RememberMe(RequestDelegate next, IAuthService authService, IServiceProvider serviceProvider, IConfiguration configuartion, IMapper mapper)
    {
        private readonly RequestDelegate _next = next;
        private readonly IAuthService _authService = authService;
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        public IConfiguration Configuartion { get; } = configuartion;
        private readonly IMapper _mapper = mapper;

        public async Task InvokeAsync(HttpContext context)
        {
            using var scope = _serviceProvider.CreateScope();
            var _userService = scope.ServiceProvider.GetRequiredService<IUserService>();
            if (context.User.Identity != null)
            {
                if (!context.User.Identity.IsAuthenticated && context.Request.Cookies.TryGetValue(AppConst.Cookies.RememberMe, out var encryptedUserId))
                {
                    var userId = EncryptionHelper.Decrypt(encryptedUserId);
                    if (int.TryParse(userId, out var id))
                    {
                        var user = await _userService.GetByIdAsync(id);
                        if (user != null)
                        {
                            var map = _mapper.Map<LoginRes>(user);
                            await _authService.SignInUser(map);
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
