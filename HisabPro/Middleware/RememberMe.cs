using Hisab.CryptoService;
using HisabPro.Constants;
using HisabPro.Repository;
using HisabPro.Services;

namespace HisabPro.Middleware
{
    public class RememberMe
    {
        private readonly RequestDelegate _next;
        private readonly AuthService _authService;
        private readonly IServiceProvider _serviceProvider;
        public RememberMe(RequestDelegate next, AuthService authService, IServiceProvider serviceProvider)
        {
            _next = next;
            _authService = authService;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

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
                await _next(context);
            }
        }
    }
}
