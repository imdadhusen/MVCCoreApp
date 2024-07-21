using HisabPro.Entities.Migrations;

namespace HisabPro.DTO.Response
{
    public class ChildCategoryRes : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
