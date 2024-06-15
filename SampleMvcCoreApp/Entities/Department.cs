using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleMvcCoreApp.Entities
{
    public class Department : ISoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        public string? DepartmentPhone {  get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
