using SampleMvcCoreApp.DTO;

namespace SampleMvcCoreApp.Repository
{
    public interface IEmployeeRepository
    {
        List<EmployeeDTO> GetAllEmployee(bool IncludeSoftDelete=false);
        //List<Employee> GetAllEmployee(bool IncludeSoftDelete = false);
    }
}
