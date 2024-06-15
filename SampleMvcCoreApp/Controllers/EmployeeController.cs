using Microsoft.AspNetCore.Mvc;
using SampleMvcCoreApp.DTO;
using SampleMvcCoreApp.Entities;
using SampleMvcCoreApp.Repository;

namespace SampleMvcCoreApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        // GET: api/<controller>  
        [HttpGet]
        public IActionResult Get()
        {
            var result = GetEmployees();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        private List<EmployeeDTO> GetEmployees()
        //private List<Employee> GetEmployees()
        {
            return _employeeRepository.GetAllEmployee();
        }
    }
}
