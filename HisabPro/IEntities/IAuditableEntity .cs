using HisabPro.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace HisabPro.IEntities
{
    public interface IAuditableEntity
    {
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public User Creator { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [ForeignKey("ModifiedBy")]
        public User Modifier { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
