using Microsoft.AspNetCore.Mvc;

namespace HisabPro.Controllers
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
