using System.Text.Json.Serialization;

namespace HisabPro.DTO.Model
{
    [JsonConverter(typeof(FilterModelConverter))]
    public abstract class BaseFilterModel
    {
        public string FieldName { get; set; }
        private string _title;
        public string FieldTitle
        {
            get => string.IsNullOrWhiteSpace(_title) ? FieldName : _title;
            set => _title = value;
        }

        // Property is used in an API response but should not be deserialized during incoming requests
        [JsonIgnore]
        public List<IdNameAndRefId>? Items { get; set; }

        // Used to automatically load reference data in child dropdown
        [JsonIgnore]
        public string? ChildFieldName { get; set; }

        [JsonIgnore]
        public List<IdNameAndRefId>? ChildItems { get; set; }
    }

    public class FilterDataType
    {
        public const string Bool = "bool";
        public const string Int = "int";
        public const string String = "string";
        public const string Date = "DateTime";
        public const string Double = "double";
    }
}