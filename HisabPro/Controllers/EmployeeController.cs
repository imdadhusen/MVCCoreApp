﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HisabPro.DTO;
using HisabPro.Entities;
using HisabPro.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using HisabPro.Constants;

namespace HisabPro.Controllers
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
