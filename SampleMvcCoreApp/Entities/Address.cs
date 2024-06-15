using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SampleMvcCoreApp.Entities
{
    public class Address :ISoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AddressDetail { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public int EmployeeId { get; set; }
    }
}
