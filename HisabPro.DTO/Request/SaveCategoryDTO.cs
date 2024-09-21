namespace HisabPro.DTO.Request
{
    public class SaveCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
