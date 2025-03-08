using HisabPro.Common;
using HisabPro.Constants.Resources;
using HisabPro.Constants;
using HisabPro.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HisabPro.DTO.Model;
using System.Text;
using Azure;

namespace HisabPro.Services.Implements
{
    public class ExportToHTMLService : IExportService
    {
        private readonly ISharedViewLocalizer _localizer;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExportToHTMLService(IHttpContextAccessor httpContextAccessor, ISharedViewLocalizer localizer)
        {
            _httpContextAccessor = httpContextAccessor;
            _localizer = localizer;
        }

        public FileContentResult Export<T>(List<T> data, string reportTitle, string reportFileName, List<Column> columns, string AppliedSortField = "NA", string AppliedSortType = "NA", int AppliedFilterCount = 0)
        {
            if (data == null || !data.Any())
                throw new CustomValidationException(_localizer.Get(ResourceKey.ApiNoRecordsForExport));

            string template = File.ReadAllText(ExportReportValues.HtmlTemplatePath);

            // Replace placeholders
            template = template.Replace("{ReportTitle}", reportTitle)
                               .Replace("{ReportDateLabel}", _localizer.Get(ResourceKey.ReportDate))
                               .Replace("{ReportDate}", DateTime.Now.ToString(ExportReportValues.DateFormatHeader))
                               .Replace("{AppliedSortLabel}", string.Format(_localizer.Get(ResourceKey.ReportAppliedSort), AppliedSortField, AppliedSortType))
                               .Replace("{AppliedFilterLabel}", string.Format(_localizer.Get(ResourceKey.ReportAppliedFilter), AppliedFilterCount))
                               .Replace("{AppliedFilterCount}", AppliedFilterCount.ToString())
                               .Replace("{LogoPath}", ExportReportValues.LogoPath)
                               .Replace("{LogoText}", ExportReportValues.LogoText)
                               .Replace("{SupportContact}", ExportReportValues.SupportContact);

            // Generate table content dynamically
            string tableHeaders = string.Join("", columns.Select(col => $"<th>{col.Title}</th>"));
            string tableRows = string.Join("", data.Select(item => GenerateRow(item, columns)));

            template = template.Replace("{TableHeaders}", tableHeaders)
                               .Replace("{TableRows}", tableRows);

            byte[] fileBytes = Encoding.UTF8.GetBytes(template);
            string fileName = $"{reportFileName}.html";

            var response = _httpContextAccessor.HttpContext.Response;
            response.Headers["X-Filename"] = fileName;
            response.Headers["Content-Disposition"] = $"attachment; filename=\"{fileName}\"";
            response.Headers["Content-Type"] = "application/octet-stream";

            return new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = fileName
            };
        }

        private string GenerateRow<T>(T item, List<Column> columns)
        {
            var properties = typeof(T).GetProperties().Where(p => p.CanRead).ToList();
            var rowContent = "<tr>";

            foreach (var column in columns)
            {
                var propertyInfo = properties.FirstOrDefault(p => p.Name == column.Name);
                var rawValue = propertyInfo?.GetValue(item);
                string cellValue = rawValue?.ToString() ?? "";

                if (column.Name == "IsActive" && rawValue is bool boolValue)
                    cellValue = boolValue ? ExportReportValues.TickMarkText : ExportReportValues.TickMarkText;
                else if (rawValue is DateTime dateValue)
                    cellValue = dateValue.ToString(ExportReportValues.DateFormatData);

                rowContent += $"<td>{cellValue}</td>";
            }

            return rowContent + "</tr>";
        }
    }

}
