﻿using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Web.ViewModel;

namespace HisabPro.Web.Helper
{
    public static class GridviewHelper
    {
        public static async Task<GridViewModel<object>> LoadGridData<T>(LoadDataRequest req, bool firstTimeLoad, Func<LoadDataRequest, Task<PageDataRes<T>>> fetchPageData, List<Column> columns)
        {
            if (req.PageData == null)
            {
                req.PageData = new PageDataReq { PageNumber = 1, PageSize = 10 };
            }

            var model = new GridViewModel<object>
            {
                PageNumber = req.PageData.PageNumber,
                PageSize = req.PageData.PageSize,
                SortBy = req.PageData?.SortBy,
                SortDirection = req.PageData?.SortDirection,
                Columns = columns
            };

            if (firstTimeLoad)
            {
                model.Filters = req.Filters;
                req.Filters = null;
            }

            var pageData = await fetchPageData(req);
            model.Data = pageData.Data.Cast<object>().ToList();
            model.TotalRecords = pageData.TotalData;

            return model;
        }
    }
}
