using Microsoft.AspNetCore.Mvc;

namespace HisabPro.Web.Controllers.Private
{
    public class ErrorController : Controller
    {
        [Route("Home/Error")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
