using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HisabPro.DTO;
using HisabPro.Entities;
using System.Collections.Generic;

namespace HisabPro.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly FilterService _filterService;
        private readonly ILogger<EmployeeRepository> _logger;
        public EmployeeRepository(ApplicationDbContext context, IMapper mapper, FilterService filterService, ILogger<EmployeeRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _filterService = filterService;
            _logger = logger;
        }
        public List<EmployeeDTO> GetAllEmployee(bool IncludeSoftDelete = false)
        //public List<Employee> GetAllEmployee(bool IncludeSoftDelete = false)
        {
            _filterService.IncludeSoftDeleted = IncludeSoftDelete;

            var lstEmp = _context.Employees
                    .Include(a => a.EmployeeAddress)
                    .Include(d => d.Department);
            List<Employee> lstEmployee = new List<Employee>();
            if (IncludeSoftDelete)
            {
                lstEmployee = lstEmp.IgnoreQueryFilters().ToList();
            }
            else
            {
                lstEmployee = lstEmp.ToList();
            }
            return _mapper.Map<List<EmployeeDTO>>(lstEmployee);
        }
    }
}
