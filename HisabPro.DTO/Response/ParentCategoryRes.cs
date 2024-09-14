using HisabPro.Entities.Migrations;

namespace HisabPro.DTO.Response
{
    public class ParentCategoryRes : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
