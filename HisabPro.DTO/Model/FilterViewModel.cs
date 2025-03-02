namespace HisabPro.DTO.Model
{
    public class FilterViewModel
    {
        public List<BaseFilterModel> Fields { get; set; } = new();
        public bool HasCreateNew { get; set; } = true;
        public bool AllowExport { get; set; } = true;
    }
}
