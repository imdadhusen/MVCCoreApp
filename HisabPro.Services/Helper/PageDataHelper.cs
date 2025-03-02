using AutoMapper;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HisabPro.Services.Helper
{
    public class PageDataHelper
    {
        public static IQueryable<T> ApplySort<T>(IQueryable<T> query, PageDataReq req)
        {
            if (req == null || string.IsNullOrEmpty(req.SortBy)) return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, req.SortBy);
            var lambda = Expression.Lambda(property, parameter);

            var methodName = req.SortDirection == "asc" ? "OrderBy" : "OrderByDescending";
            var method = typeof(Queryable).GetMethods()
                .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), property.Type);

            return (IQueryable<T>)method.Invoke(null, new object[] { query, lambda });
        }

        public static async Task<PageDataRes<T>> ApplyPage<S, T>(IQueryable<S> query, PageDataReq req, IMapper mapper)
        {
            var total = await query.CountAsync();
            var data = await query.Skip((req.PageNumber - 1) * req.PageSize).Take(req.PageSize).ToListAsync();
            var mappedData = mapper.Map<List<T>>(data);
            return new PageDataRes<T> { Data = mappedData, TotalData = total };
        }

        public static async Task<PageDataRes<T>> ApplyAllPage<S, T>(IQueryable<S> query, PageDataReq req, IMapper mapper)
        {
            var data = await query.ToListAsync();
            var mappedData = mapper.Map<List<T>>(data);
            return new PageDataRes<T> { Data = mappedData };
        }
    }
}
