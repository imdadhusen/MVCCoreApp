using HisabPro.Constants;
using HisabPro.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace HisabPro.Web.Middleware
{
    public class PasswordExpiry
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;
        private readonly AppSettings _appSettings;
        private readonly IAuthService _authService;

        public PasswordExpiry(RequestDelegate next, IServiceProvider serviceProvider, IOptions<AppSettings> appSettings, IAuthService authService)
        {
            _next = next;
            _serviceProvider = serviceProvider;
            _appSettings = appSettings.Value;
            _authService = authService;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (context.User?.Identity?.IsAuthenticated == true)
                {
                    using var scope = _serviceProvider.CreateScope();
                    var _userService = scope.ServiceProvider.GetRequiredService<IUserService>();

                    var id = _authService.GetCurrentUserId();
                    var user = await _userService.GetByIdAsync(id);

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
            }
            catch(Exception ex)
            {

            }
            await _next(context);
        }
    }
}
