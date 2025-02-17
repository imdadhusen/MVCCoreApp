using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HisabPro.Web.Controllers.Public
{
    public class HomeController : Controller
    {
        private readonly string sharedController = "/Views/Shared/{0}.cshtml";
        private readonly ISharedViewLocalizer _localizer;

        public HomeController(ISharedViewLocalizer localizer)
        {
            _localizer = localizer;
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
        public IActionResult SetLanguage([FromBody] SetLanguageReq req)
        {
            ResponseDTO<bool> response = new ResponseDTO<bool>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = _localizer.Get(ResourceKey.ApiSuccess),
                Response = true
            };
            try
            {

                if (!string.IsNullOrEmpty(req.Culture))
                {
                    Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);
                    Response.Cookies.Append(
                        CookieRequestCultureProvider.DefaultCookieName,
                        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(req.Culture)),
                        new CookieOptions
                        {
                            Expires = DateTimeOffset.UtcNow.AddYears(1),
                            HttpOnly = false,
                            Secure = false,
                            IsEssential = true
                        }
                    );
                }
            }
            catch
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Message = _localizer.Get(ResourceKey.ErrorInChangeLang);
                response.Response = false;
            }
            //return LocalRedirect(req.ReturnUrl);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
