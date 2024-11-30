namespace HisabPro.DTO.Model
{
    public class FilterModel<T> : BaseFilterModel
    {
        public T StartValue { get; set; }
        public T? EndValue { get; set; }
        public IEnumerable<T>? RangeValue { get; set; } // For IN clause
    }
}
