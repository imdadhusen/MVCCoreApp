using HisabPro.Entities.Models;

namespace HisabPro.DTO.Response
{
    public class CategoryListRes : AuditableEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<ChildCategoryRes> ChildCategories { get; set; }
    }
}
