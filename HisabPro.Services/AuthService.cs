using HisabPro.Constants;
using HisabPro.DTO.Response;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HisabPro.Services
{
    public class AuthService(IConfiguration configuartion, IHttpContextAccessor contextAccessor)
    {
        public IConfiguration Configuartion { get; } = configuartion;
        private readonly IHttpContextAccessor _contextAccessor = contextAccessor;

        public List<Claim> GetClaims(LoginRes user)
        {
            UserRoleEnum userRole = (UserRoleEnum)user.UserRole;
            // Create claims
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, userRole.GetText())
            };
            return claims;
        }

        public async Task<string?> SignInUser(LoginRes user)
        {
            HttpContext? context = _contextAccessor.HttpContext;
            if (context != null)
            {
                var claims = GetClaims(user);
                // Create claims identity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                // Create claims principal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                // Sign in the user
                var authProperties = new AuthenticationProperties
                {
                    // Set properties like IsPersistent to control cookie behavior
                    IsPersistent = true
                };
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);
                
                // Manually set HttpContext.User for user setting password first time
                context.User = claimsPrincipal;

                return GenerateToken(claims);
            }
            return null;
        }

        public string GenerateToken(List<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuartion[AppConst.Configs.JwtKey]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
