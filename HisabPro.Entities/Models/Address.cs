using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HisabPro.Entities.Models
{
    public class Address : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AddressDetail { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        //Navigation property
        public Employee Employee { get; set; }
    }
}
