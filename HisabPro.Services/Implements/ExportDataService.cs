using HisabPro.Common;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using ColType = HisabPro.DTO.Model;

namespace HisabPro.Services.Implements
{
    public class ExportDataService : IExportDataService
    {
        private readonly IExportService _pdfExportService;
        //private readonly IExportService _excelExportService;
        private readonly IExportService _htmlExportService;
        private readonly ISharedViewLocalizer _localizer;

        //[FromKeyedServices("Excel")] IExportService excelExportService
        public ExportDataService([FromKeyedServices("PDF")] IExportService pdfExportService, [FromKeyedServices("HTML")] IExportService htmlExportService, ISharedViewLocalizer localizer)
        {
            _pdfExportService = pdfExportService;
            _htmlExportService = htmlExportService;
            _localizer = localizer;
            // Configure generic helper for Enum
            EnumLocalizationHelper.Configure(_localizer);
        }

        public FileContentResult Export<T>(List<T>? data, EnumReportTitle reportTitle, ExportReq reqExport, List<Column> columns)
        {
            IExportService exportService = reqExport.ExportType switch
            {
                EnumExportType.PDF => _pdfExportService,
                //EnumExportType.Excel => _excelExportService,
                EnumExportType.HTML => _htmlExportService,
                _ => throw new FeatureNotAvailableException(_localizer.Get(ResourceKey.ApiFeatureNotAvailable))
            };

            var showOnlyDataColumns = columns.Where(c => !(c.Type == ColType.Type.Edit || c.Type == ColType.Type.Delete)).ToList();
            string sortBy = getLocalizedColumnTitle(columns, reqExport.PageData?.SortBy);
            string sortOrder = getLocalizedSort(reqExport.PageData?.SortDirection);
            int filterCount = reqExport.Filter?.Fields?.Count() ?? 0;
            string title = EnumLocalizationHelper.Get(reportTitle);
            return exportService.Export(data, title, reportTitle.ToString(), showOnlyDataColumns, sortBy, sortOrder, filterCount);
        }

        private string getLocalizedColumnTitle(List<Column> columns, string? columnName)
        {
            if (!string.IsNullOrEmpty(columnName))
            {
                var col = columns.Where(c => c.Name == columnName).FirstOrDefault();
                if (col != null)
                    return col.Title;
            }
            return _localizer.Get(ResourceKey.ReportNA);
        }

        private string getLocalizedSort(string? columnSort)
        {
            if (!string.IsNullOrEmpty(columnSort))
            {
                return (columnSort.ToUpper() == "ASC") ? _localizer.Get(ResourceKey.ReportSortAsc) : _localizer.Get(ResourceKey.ReportSortDes);
            }
            return _localizer.Get(ResourceKey.ReportNA);
        }
    }
}