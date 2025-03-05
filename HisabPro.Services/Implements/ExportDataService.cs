using HisabPro.Common;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;

namespace HisabPro.Services.Implements
{
    public class ExportDataService : IExportDataService
    {
        private readonly IExportService _pdfExportService;
        //private readonly IExportService _excelExportService;
        //private readonly IExportService _htmlExportService;
        private readonly ISharedViewLocalizer _localizer;

        //[FromKeyedServices("Excel")] IExportService excelExportService,        [FromKeyedServices("HTML")]        IExportService htmlExportService)
        public ExportDataService([FromKeyedServices("PDF")] IExportService pdfExportService, ISharedViewLocalizer localizer)
        {
            _pdfExportService = pdfExportService;
            _localizer = localizer;
        }

        public FileContentResult Export<T>(List<T>? data, string reportTitle, ExportReq reqExport, List<Column> columns)
        {
            IExportService exportService = reqExport.ExportType switch
            {
                EnumExportType.PDF => _pdfExportService,
                //EnumExportType.Excel => _excelExportService,
                //EnumExportType.HTML => _htmlExportService,
                _ => throw new FeatureNotAvailableException(_localizer.Get(ResourceKey.ApiFeatureNotAvailable))
            };

            var showOnlyDataColumns = columns.Where(c => !(c.Type == DTO.Model.Type.Edit || c.Type == DTO.Model.Type.Delete)).ToList();
            string sortBy = reqExport.PageData?.SortBy ?? "NA";
            string sortOrder = reqExport.PageData?.SortDirection ?? "NA";
            int filterCount = reqExport.Filter?.Fields?.Count() ?? 0;
            return exportService.Export(data, reportTitle, showOnlyDataColumns, sortBy, sortOrder, filterCount);
        }
    }
}