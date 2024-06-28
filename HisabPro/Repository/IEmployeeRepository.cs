using HisabPro.DTO;

namespace HisabPro.Repository
{
    public interface IEmployeeRepository
    {
        List<EmployeeDTO> GetAllEmployee(bool IncludeSoftDelete=false);
        //List<Employee> GetAllEmployee(bool IncludeSoftDelete = false);
    }
}
