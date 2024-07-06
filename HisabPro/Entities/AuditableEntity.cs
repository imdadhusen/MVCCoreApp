using HisabPro.Helper;
using HisabPro.IEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace HisabPro.Entities
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        public DateTime CreatedOn { get; set; } = DateHelper.GetUTC;
        public int CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public User Creator { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [ForeignKey("ModifiedBy")]
        public User Modifier { get; set; }

        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
