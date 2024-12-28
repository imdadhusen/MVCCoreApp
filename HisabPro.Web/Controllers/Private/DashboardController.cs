using Microsoft.AspNetCore.Mvc;

namespace HisabPro.Web.Controllers.Private
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
