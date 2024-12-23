namespace HisabPro.DTO.Response
{
    public class CategoryRes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; } // Optional for parent details
        public string Type { get; set; } // Resolved to enum text
        public bool IsStandard { get; set; }
        public List<CategoryRes> SubCategories { get; set; } = new List<CategoryRes>();

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
