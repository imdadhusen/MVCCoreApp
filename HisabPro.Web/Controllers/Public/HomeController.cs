using HisabPro.DTO.Model;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HisabPro.Web.Controllers.Public
{
    public class HomeController : Controller
    {
        private readonly string sharedController = "/Views/Shared/{0}.cshtml";

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Home/Error")]
        public IActionResult Error()
        {
            var errorViewModel = new ErrorDTO
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(string.Format(sharedController, "Error"), errorViewModel);
        }

        [Route("Home/Unauthorized")]
        public new IActionResult Unauthorized()
        {
            var errorViewModel = new ErrorDTO
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(string.Format(sharedController, "Unauthorized"), errorViewModel);
        }

        [HttpGet]
        [Route("Home/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View(string.Format(sharedController, "AccessDenied"));
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            if (!string.IsNullOrEmpty(culture))
            {
                Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddYears(1),
                        HttpOnly = false,
                        Secure = false,
                        IsEssential = true
                    }
                );
            }
            //return LocalRedirect(returnUrl);
            return Json(new { success = true });
        }
    }
}
