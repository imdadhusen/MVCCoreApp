using HisabPro.Entities.Models;

namespace HisabPro.DTO.Model
{
    public class EmployeeDTO : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public string Email { get; set; }
       
        public List<AddressDTO> Address { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
