using System.Text.Json;
using System.Text.Json.Serialization;

namespace HisabPro.DTO.Model
{
    public class FilterModelConverter : JsonConverter<BaseFilterModel>
    {
        public FilterModelConverter() { }

        public override BaseFilterModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            // Read the "FieldName" to determine the filter type
            if (jsonObject.TryGetProperty("FieldName", out _))
            {
                // Determine the filter type based on properties present in the JSON
                if (jsonObject.TryGetProperty("RangeValue", out _))
                {
                    if (jsonObject.TryGetProperty("RangeValue", out var rangeValue) && rangeValue.ValueKind == JsonValueKind.Array && rangeValue[0].ValueKind == JsonValueKind.Number)
                    {
                        return JsonSerializer.Deserialize<FilterModel<int>>(jsonObject.GetRawText(), options);
                    }
                    if (jsonObject.TryGetProperty("RangeValue", out _) && jsonObject[0].TryGetProperty("StartValue", out _))
                    {
                        return JsonSerializer.Deserialize<FilterModel<DateTime>>(jsonObject.GetRawText(), options);
                    }
                }
                else if (jsonObject.TryGetProperty("StartValue", out var startValue))
                {
                    if (startValue.ValueKind == JsonValueKind.Number)
                    {
                        return JsonSerializer.Deserialize<FilterModel<int>>(jsonObject.GetRawText(), options);
                    }
                    if (startValue.ValueKind == JsonValueKind.String && DateTime.TryParse(startValue.GetString(), out _))
                    {
                        return JsonSerializer.Deserialize<FilterModel<DateTime>>(jsonObject.GetRawText(), options);
                    }
                    if (startValue.ValueKind == JsonValueKind.True || startValue.ValueKind == JsonValueKind.False)
                    {
                        return JsonSerializer.Deserialize<FilterModel<bool>>(jsonObject.GetRawText(), options);
                    }
                    if (startValue.ValueKind == JsonValueKind.String)
                    {
                        return JsonSerializer.Deserialize<FilterModel<string>>(jsonObject.GetRawText(), options);
                    }
                }
            }

            throw new JsonException("Unable to determine filter type.");
        }

        public override void Write(Utf8JsonWriter writer, BaseFilterModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
