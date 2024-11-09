using Hisab.CryptoService;
using HisabPro.Constants;
using HisabPro.DTO.Request;
using HisabPro.Repository.Interfaces;
using HisabPro.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HisabPro.Web.Controllers
{
    public class UserController(IUserRepository userRpository, AuthService authService) : Controller
    {
        public IUserRepository UserRpository { get; } = userRpository;
        public AuthService AuthService { get; } = authService;

        [AllowAnonymous]
        [HttpGet("user/login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Redirect to the desired page if the user is already authenticated
                return RedirectToAction("Index", "Home");
            }
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                var user = await UserRpository.Authenticate(login.Email, login.Password);
                if (user == null)
                {
                    return Unauthorized();
                }
                else
                {
                    var tokenString = await AuthService.SignInUser(user);
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
