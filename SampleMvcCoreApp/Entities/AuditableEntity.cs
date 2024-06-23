using SampleMvcCoreApp.IEntities;

namespace SampleMvcCoreApp.Entities
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
