using Hisab.CryptoService;
using HisabPro.Constants;
using HisabPro.DTO;
using HisabPro.Repository;
using HisabPro.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace HisabPro.Controllers
{
    public class AccountController : Controller
    {
        public IUserRepository _userRpository { get; }
        public AuthService _authService { get; }

        public AccountController(IUserRepository userRpository, AuthService authService)
        {
            _userRpository = userRpository;
            _authService = authService;
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
            if (ModelState.IsValid)
            {
                var user = await _userRpository.Authenticate(login.Email, login.Password);
                if (user == null)
                {
                    return Unauthorized();
                }
                else
                {
                    var tokenString = await _authService.SignInUser(user);
                    if (login.RememberMe)
                    {
                        var encryptedUserId = EncryptionHelper.Encrypt(user.Id.ToString());
                        // Set a persistent cookie
                        Response.Cookies.Append(AppConst.Cookies.RememberMe, encryptedUserId,
                            new CookieOptions
                            {
                                Expires = DateTimeOffset.Now.AddDays(30),
                                HttpOnly = true,
                                Secure = true // Ensure the cookie is only sent over HTTPS
                            });
                    }
                    else
                    {
                        // Clear the cookie if not remembered
                        Response.Cookies.Delete(AppConst.Cookies.RememberMe);
                    }
                    return Ok(new { Token = tokenString });
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, MessageConst.Validations.ValidationFailed);
                return View(login);
            }
        }

        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Clear the "Remember Me" cookie
            Response.Cookies.Delete(AppConst.Cookies.RememberMe);
            return RedirectToAction("Index", "Home"); // Redirect to login page or another page after logout
        }
    }
}
