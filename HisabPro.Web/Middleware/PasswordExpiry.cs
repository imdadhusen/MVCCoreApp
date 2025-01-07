using HisabPro.Constants;
using HisabPro.Entities.IEntities;
using HisabPro.Repository.Interfaces;
using HisabPro.Services;
using Microsoft.Extensions.Options;

namespace HisabPro.Web.Middleware
{
    public class PasswordExpiry
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;
        private readonly AppSettings _appSettings;
        private readonly AuthService _authService;

        public PasswordExpiry(RequestDelegate next, IServiceProvider serviceProvider, IOptions<AppSettings> appSettings, AuthService authService)
        {
            _next = next;
            _serviceProvider = serviceProvider;
            _appSettings = appSettings.Value;
            _authService = authService;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.User?.Identity?.IsAuthenticated == true)
            {
                using var scope = _serviceProvider.CreateScope();
                var _userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

                var id = _authService.GetCurrentUserId();
                var user = await _userRepository.GetUser(u => u.Id == id);

                if (user != null)
                {
                    var daysSinceLastChange = user.PasswordChangedOn.HasValue ? (DateTime.UtcNow - user.PasswordChangedOn.Value).TotalDays : 0;
                    if (daysSinceLastChange > _appSettings.User.MustChangePasswordInDays || user.MustChangePassword)
                    {
                        context.Response.Redirect("/User/ForcePasswordChange");
                        return;
                    }
                }
            }
            await _next(context);
        }
    }
}
