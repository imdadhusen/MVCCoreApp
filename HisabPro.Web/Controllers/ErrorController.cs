using Microsoft.AspNetCore.Mvc;

namespace HisabPro.Web.Controllers
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
