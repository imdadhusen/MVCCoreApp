using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using HisabPro.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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

        public FileContentResult Export<T>(List<T> data, string reportTitle, string reportFileName, List<Column> columns, List<FilterDescriptionModel>? filterDescriptions, string AppliedSortField = "NA", string AppliedSortType = "NA")
        {
            string template = File.ReadAllText(ExportReportValues.HtmlTemplatePath);

            // Replace placeholders
            template = template.Replace("{ReportTitle}", reportTitle)
                               .Replace("{ReportDateLabel}", _localizer.Get(ResourceKey.ReportDate))
                               .Replace("{ReportDate}", DateTime.Now.ToString(ExportReportValues.DateFormatHeader))
                               .Replace("{AppliedSortLabel}", string.Format(_localizer.Get(ResourceKey.ReportAppliedSort), AppliedSortField, AppliedSortType))
                               .Replace("{AppliedFilterLabel}", string.Format(_localizer.Get(ResourceKey.ReportAppliedFilter), filterDescriptions?.Count))
                               .Replace("{AppliedFilterCount}", filterDescriptions?.Count.ToString())
                               .Replace("{LogoPath}", ExportReportValues.LogoPath)
                               .Replace("{LogoText}", ExportReportValues.LogoText)
                               .Replace("{SupportContact}", ExportReportValues.SupportContact);

            // Generate table content dynamically
            string tableHeaders = string.Join("", columns.Select(col => $"<th {getAlignStyle(col.Align)}>{col.Title}</th>"));
            string tableRows = string.Join("", data.Select(item => GenerateRow(item, columns)));

            template = template.Replace("{TableHeaders}", tableHeaders)
                               .Replace("{TableRows}", tableRows);

            byte[] fileBytes = Encoding.UTF8.GetBytes(template);
            string fileName = $"{reportFileName}.html";

            var response = _httpContextAccessor.HttpContext.Response;
            response.Headers["X-Filename"] = fileName;
            response.Headers["Content-Disposition"] = $"attachment; filename=\"{fileName}\"";
            response.Headers["Content-Type"] = ExportReportValues.HtmlContentType;

            return new FileContentResult(fileBytes, ExportReportValues.HtmlContentType)
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

                rowContent += $"<td {getAlignStyle(column.Align)}>{cellValue}</td>";
            }

            return rowContent + "</tr>";
        }

        private string getAlignStyle(Align columnAlign)
        {
            string? align = null;
            switch (columnAlign)
            {
                case Align.Center:
                    align = "center";
                    break;
                case Align.Right:
                    align = "right";
                    break;
            }
            return align != null ? $"style='text-align:{align}'" : "";
        }
    }

}
