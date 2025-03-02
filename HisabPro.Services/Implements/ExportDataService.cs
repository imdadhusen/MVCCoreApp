using HisabPro.Common;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using HisabPro.DTO.Model;

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

        public FileContentResult Export<T>(List<T>? data, string reportTitle, EnumExportType exportType, List<Column> columns)
        {
            IExportService exportService = exportType switch
            {
                EnumExportType.PDF => _pdfExportService,
                //EnumExportType.Excel => _excelExportService,
                //EnumExportType.HTML => _htmlExportService,
                _ => throw new FeatureNotAvailableException(_localizer.Get(ResourceKey.ApiFeatureNotAvailable))
            };

            return exportService.Export(data, reportTitle, columns);
        }
    }
}