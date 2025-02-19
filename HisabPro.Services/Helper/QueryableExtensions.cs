using HisabPro.DTO.Model;
using Microsoft.EntityFrameworkCore;

namespace HisabPro.Services.Helper
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyDynamicFilters<T>(this IQueryable<T> query, List<BaseFilterModel>? filters)
        {
            if (filters == null || filters.Count == 0)
                return query;

            foreach (var baseFilter in filters)
            {
                var property = typeof(T).GetProperty(baseFilter.FieldName);
                if (property == null) continue;

                switch (baseFilter)
                {
                    case FilterModel<bool> boolFilter:
                        query = query.Where(x => EF.Property<bool>(x, boolFilter.FieldName) == boolFilter.StartValue);
                        break;
                    case FilterModel<int> intFilter:
                        if (intFilter.RangeValue != null && intFilter.RangeValue.Any())
                        {
                            query = query.Where(x => intFilter.RangeValue.Contains(EF.Property<int>(x, intFilter.FieldName)));
                        }
                        else if (intFilter.StartValue != default && intFilter.EndValue != default)
                        {
                            query = query.Where(x => EF.Property<int>(x, intFilter.FieldName) >= intFilter.StartValue &&
                            EF.Property<int>(x, intFilter.FieldName) <= intFilter.EndValue);
                        }
                        else if (intFilter.StartValue != default)
                        {
                            query = query.Where(x => EF.Property<int>(x, intFilter.FieldName) == intFilter.StartValue);
                        }
                        break;
                    case FilterModel<DateTime> dateTimeFilter:
                        if (dateTimeFilter.StartValue != default && dateTimeFilter.EndValue != default)
                        {
                            query = query.Where(x => EF.Property<DateTime>(x, dateTimeFilter.FieldName) >= dateTimeFilter.StartValue &&
                            EF.Property<DateTime>(x, dateTimeFilter.FieldName) <= dateTimeFilter.EndValue);
                        }
                        else if (dateTimeFilter.StartValue != default)
                        {
                            query = query.Where(x => EF.Property<DateTime>(x, dateTimeFilter.FieldName) == dateTimeFilter.StartValue);
                        }
                        break;
                    case FilterModel<string> stringFilter:
                        if (stringFilter.RangeValue != null && stringFilter.RangeValue.Any())
                        {
                            query = query.Where(x => stringFilter.RangeValue.Contains(EF.Property<string>(x, stringFilter.FieldName)));
                        }
                        else if (!string.IsNullOrEmpty(stringFilter.StartValue))
                        {
                            query = query.Where(x => EF.Property<string>(x, stringFilter.FieldName).Contains(stringFilter.StartValue));
                        }
                        break;
                }
            }
            return query;
        }
    }

}
