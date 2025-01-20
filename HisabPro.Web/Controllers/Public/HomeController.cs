using HisabPro.DTO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace HisabPro.Web.Controllers.Public
{
    public class HomeController : Controller
    {
        private readonly string sharedController = "/Views/Shared/{0}.cshtml";
        private readonly IStringLocalizer _localizer;

        public HomeController(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create("SharedResource", "HisabPro.Web");
        }

        public IActionResult Index()
        {
            ViewData["WelcomeMessage"] = _localizer["WelcomeMessage"];
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
    }
}
