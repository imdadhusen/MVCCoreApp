using AutoMapper;
using HisabPro.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HisabPro.Services.Helper
{
    public class PageDataHelper
    {
        public static IQueryable<T> ApplySort<T>(IQueryable<T> query, string? sortBy, string? sortDirection)
        {
            if (string.IsNullOrEmpty(sortBy)) return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, sortBy);
            var lambda = Expression.Lambda(property, parameter);

            var methodName = sortDirection == "asc" ? "OrderBy" : "OrderByDescending";
            var method = typeof(Queryable).GetMethods()
                .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), property.Type);

            return (IQueryable<T>)method.Invoke(null, new object[] { query, lambda });
        }

        public static async Task<PageDataRes<T>> ApplyPage<S,T>(IQueryable<S> query, int pageNumber, int pageSize, IMapper mapper)
        {
            var total = await query.CountAsync();
            var data = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var mappedData = mapper.Map<List<T>>(data);
            var pageData = new PageDataRes<T>() { Data = mappedData, TotalData = total };
            return pageData;
        }
    }
}
