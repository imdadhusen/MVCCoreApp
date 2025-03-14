using HisabPro.Constants;

namespace HisabPro.DTO.Model
{
    public class FilterViewModel
    {
        public List<BaseFilterModel> Fields { get; set; } = new();
        public bool HasCreateNew { get; set; } = true;
        public bool AllowExport { get; set; } = true;

        public List<FilterDescriptionModel> GetFilterDescription()
        {
            var filterDescription = new List<FilterDescriptionModel>();
            if (Fields == null || Fields.Count == 0)
                return filterDescription;

            foreach (var baseFilter in Fields)
            {
                switch (baseFilter)
                {
                    case FilterModel<bool> boolFilter:
                        filterDescription.Add(new FilterDescriptionModel() { FilterName = boolFilter.FieldTitle, Description = $"is {boolFilter.StartValue}" });
                        break;
                    case FilterModel<int> intFilter:
                        if (intFilter.RangeValue != null && intFilter.RangeValue.Any())
                        {
                            filterDescription.Add(new FilterDescriptionModel() { FilterName = intFilter.FieldTitle, Description = $"contains {intFilter.FiledTextValue}" });
                        }
                        else if (intFilter.StartValue != default && intFilter.EndValue != default)
                        {
                            filterDescription.Add(new FilterDescriptionModel() { FilterName = intFilter.FieldTitle, Description = $"between {intFilter.StartValue} and {intFilter.EndValue}" });
                        }
                        else if (intFilter.StartValue != default)
                        {
                            filterDescription.Add(new FilterDescriptionModel() { FilterName = intFilter.FieldTitle, Description = $"is {intFilter.FiledTextValue}" });
                        }
                        break;
                    case FilterModel<double> doubleFilter:
                        if (doubleFilter.RangeValue != null && doubleFilter.RangeValue.Any())
                        {
                            filterDescription.Add(new FilterDescriptionModel() { FilterName = doubleFilter.FieldTitle, Description = $"contains {doubleFilter.FiledTextValue}" });
                        }
                        else if (doubleFilter.StartValue != default && doubleFilter.EndValue != default)
                        {
                            filterDescription.Add(new FilterDescriptionModel() { FilterName = doubleFilter.FieldTitle, Description = $"between {doubleFilter.StartValue} and {doubleFilter.EndValue}" });
                        }
                        else if (doubleFilter.StartValue != default)
                        {
                            filterDescription.Add(new FilterDescriptionModel() { FilterName = doubleFilter.FieldTitle, Description = $"is {doubleFilter.FiledTextValue}" });
                        }
                        break;
                    case FilterModel<DateTime> dateTimeFilter:
                        if (dateTimeFilter.StartValue != default && dateTimeFilter.EndValue != default)
                        {
                            filterDescription.Add(new FilterDescriptionModel() { FilterName = dateTimeFilter.FieldTitle, Description = $"between {dateTimeFilter.StartValue.ToString(ExportReportValues.DateFormatData)} and {dateTimeFilter.EndValue.ToString(ExportReportValues.DateFormatData)}" });
                        }
                        else if (dateTimeFilter.StartValue != default)
                        {
                            filterDescription.Add(new FilterDescriptionModel() { FilterName = dateTimeFilter.FieldTitle, Description = $"is {dateTimeFilter.StartValue.ToString(ExportReportValues.DateFormatData)}" });
                        }
                        break;
                    case FilterModel<string> stringFilter:
                        if (stringFilter.RangeValue != null && stringFilter.RangeValue.Any())
                        {
                            filterDescription.Add(new FilterDescriptionModel() { FilterName = stringFilter.FieldTitle, Description = $"contains {stringFilter.FiledTextValue}" });
                        }
                        else if (!string.IsNullOrEmpty(stringFilter.StartValue))
                        {
                            filterDescription.Add(new FilterDescriptionModel() { FilterName = stringFilter.FieldTitle, Description = $"contains {stringFilter.StartValue}" });
                        }
                        break;
                }
            }
            return filterDescription;
        }
    }
}
