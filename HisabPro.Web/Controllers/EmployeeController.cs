using HisabPro.Constants;
using HisabPro.Web.DTO;
using HisabPro.Web.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HisabPro.Web.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

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
