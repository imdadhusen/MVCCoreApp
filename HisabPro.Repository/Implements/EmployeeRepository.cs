using AutoMapper;
using HisabPro.Entities.Models;
using Microsoft.EntityFrameworkCore;
using HisabPro.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using HisabPro.DTO.Model;

namespace HisabPro.Repository.Implements
{
    public class EmployeeRepository(ApplicationDbContext context, IMapper mapper, FilterService filterService, ILogger<EmployeeRepository> logger) : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly FilterService _filterService = filterService;
        //private readonly ILogger<EmployeeRepository> _logger = logger;

        public List<EmployeeDTO> GetAllEmployee(bool IncludeSoftDelete = false)
        //public List<Employee> GetAllEmployee(bool IncludeSoftDelete = false)
        {
            _filterService.IncludeSoftDeleted = IncludeSoftDelete;

            var lstEmp = _context.Employees
                    .Include(a => a.EmployeeAddress)
                    .Include(d => d.Department);
            List<Employee> lstEmployee = [];
            if (IncludeSoftDelete)
            {
                lstEmployee = [.. lstEmp.IgnoreQueryFilters()];
            }
            else
            {
                lstEmployee = [.. lstEmp];
            }
            return _mapper.Map<List<EmployeeDTO>>(lstEmployee);
        }
    }
}
