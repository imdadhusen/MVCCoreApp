using HisabPro.Constants;
using HisabPro.DTO.Model;
using HisabPro.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HisabPro.Web.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    public class EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository) : Controller
    {
        //private readonly ILogger<EmployeeController> _logger = logger;
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        // GET: api/<controller>  
        //[HttpGet]
        [HttpGet("employee/Index")]
        public IActionResult Index()
        {
            //var result = GetEmployees();
            //if (result == null)
            //{
            //    return NotFound();
            //}
            //return Ok(result);
            return View();
        }

        [HttpGet("employee/Report")]
        [Authorize(Policy = AuthorizePolicy.RequiredRoleAdmin)]
        public IActionResult Report()
        {
            return View();
        }

        private List<EmployeeDTO> GetEmployees()
        //private List<Employee> GetEmployees()
        {
            return _employeeRepository.GetAllEmployee();
        }
    }
}
