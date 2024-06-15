namespace SampleMvcCoreApp.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public List<AddressDTO> Address { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
