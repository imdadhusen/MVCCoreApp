using HisabPro.Web.DTO;

namespace HisabPro.Web.Repository
{
    public interface IEmployeeRepository
    {
        List<EmployeeDTO> GetAllEmployee(bool IncludeSoftDelete=false);
        //List<Employee> GetAllEmployee(bool IncludeSoftDelete = false);
    }
}
