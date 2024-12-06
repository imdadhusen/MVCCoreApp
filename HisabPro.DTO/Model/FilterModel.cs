namespace HisabPro.DTO.Model
{
    public class FilterModel<T> : BaseFilterModel
    {
        public T? StartValue { get; set; } = default;
        public T? EndValue { get; set; } = default;
        public IEnumerable<T>? RangeValue { get; set; } = default;// For IN clause

        public FilterModel() { }
    }
}
