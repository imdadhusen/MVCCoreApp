using HisabPro.DTO;
using HisabPro.Repository;
using HisabPro.Tools.PasswordService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HisabPro.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class AccountController : Controller
    {
        public IConfiguration _configuartion { get; }
        public IUserRepository _userRpository { get; }

        public AccountController(IConfiguration configuartion, IUserRepository userRpository)
        {
            _configuartion = configuartion;
            _userRpository = userRpository;
        }

        [HttpGet("account/login")]
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginReqDTO login)
        {
            var user = await _userRpository.Authenticate(login.Email, login.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                if (login.RememberMe)
                {
                    // Set a persistent cookie
                    Response.Cookies.Append("HisabPro.RememberMe", "true", new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30), HttpOnly = true });
                }
                else
                {
                    // Clear the cookie if not remembered
                    Response.Cookies.Delete("HisabPro.RememberMe");
                }

                // Create claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, login.Email)
                };
                // Create claims identity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                // Create claims principal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                // Sign in the user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuartion["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
