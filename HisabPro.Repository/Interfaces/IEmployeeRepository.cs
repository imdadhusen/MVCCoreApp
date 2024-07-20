using HisabPro.DTO.Model;

namespace HisabPro.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        List<EmployeeDTO> GetAllEmployee(bool IncludeSoftDelete=false);
        //List<Employee> GetAllEmployee(bool IncludeSoftDelete = false);
    }
}
