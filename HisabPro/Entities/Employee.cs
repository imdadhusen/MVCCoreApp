using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HisabPro.Entities
{
    public class Employee : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Skill { get; set; }
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public ICollection<Address> EmployeeAddress { get; set; }
    }
}
