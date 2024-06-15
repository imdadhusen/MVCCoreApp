using Microsoft.AspNetCore.Mvc;
using SampleMvcCoreApp.Models;
using SampleMvcCoreApp.Repository;
using System.Diagnostics;

namespace SampleMvcCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Getting employee information");
            var lstEmployee = _employeeRepository.GetAllEmployee(false);
            _logger.LogInformation($"Total {lstEmployee.Count} employees found");
            return View(lstEmployee);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
