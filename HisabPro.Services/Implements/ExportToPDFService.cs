using HisabPro.Common;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using HisabPro.Services.Helper;
using HisabPro.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace HisabPro.Services.Implements
{
    public class ExportToPDFService : IExportService
    {
        private readonly ISharedViewLocalizer _localizer;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string tickMarkPath = "wwwroot/icons/Tick-Mark.png";  // ✅ Image for Active Users
        private const string logoPath = "wwwroot/icons/Logo.png";  // Company Logo
        private const string logoText = "HisabPro";
        private const string supportContact = "📞 +91 9909544184";
        private const string pdfContentType = "application/pdf";
        private const string dateFormatHeader = "dd-MM-yyyy HH:mm";
        private const string dateFormatData = "dd-MM-yyyy";

        public ExportToPDFService(IHttpContextAccessor httpContextAccessor, ISharedViewLocalizer localizer)
        {
            _httpContextAccessor = httpContextAccessor;
            _localizer = localizer;
        }

        public FileContentResult Export<T>(List<T> data, string reportTitle, List<Column> columns)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            if (data == null || !data.Any())
                throw new CustomValidationException(_localizer.Get(ResourceKey.ApiNoRecordsForExport));

            // Get properties with Display Names
            var properties = typeof(T).GetProperties()
                .Where(p => p.CanRead)
                .Select(p => new
                {
                    Property = p,
                    //DisplayName = p.GetCustomAttribute<DisplayAttribute>()?.Name ?? p.Name
                })
                .ToList();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.DefaultTextStyle(TextStyle.Default.FontSize(10)); // Set default font size

                    // Report Header Section
                    page.Header().BorderBottom(1).BorderColor(Colors.Grey.Darken2).PaddingVertical(5).Row(header =>
                    {
                        // Left: Careated Date and Time
                        //header.RelativeItem().Text(text =>
                        //{
                        //    text.Span("Report Date: ").SemiBold();
                        //    text.Span(DateTime.Now.ToString("dd-MM-yyyy HH:mm")).FontColor(Colors.Grey.Darken2);
                        //});
                        header.RelativeItem().Column(col =>
                        {
                            col.Item().Text("Report Date").SemiBold();
                            col.Item().Text(DateTime.Now.ToString(dateFormatHeader)).FontColor(Colors.Grey.Darken2); // Value below (lighter)
                        });

                        // Center: Report Title
                        header.RelativeItem().AlignCenter().Text(reportTitle).FontSize(14).SemiBold().FontColor(Colors.Blue.Darken3);

                        // Right: For Period Start and End Date
                        //header.RelativeItem().AlignRight().Text(text =>
                        //{
                        //    text.Span("Reporting Period: ").SemiBold();
                        //    text.Span(string.Format("{0:dd-MM-yyyy} - {1:dd-MM-yyyy}", DateTime.UtcNow, DateTime.UtcNow)).FontColor(Colors.Grey.Darken2);
                        //});
                        header.RelativeItem().AlignRight().Column(col =>
                        {
                            col.Item().Text("Reporting Period").SemiBold();
                            col.Item().Text(string.Format("{0:dd-MM-yyyy} - {1:dd-MM-yyyy}", DateTime.UtcNow, DateTime.UtcNow)).FontColor(Colors.Grey.Darken2); // Value below (lighter)
                        });
                    });

                    // Table Content
                    page.Content().PaddingTop(5).Table(table =>
                    {
                        table.ColumnsDefinition(headerCol =>
                        {
                            foreach (var col in columns)
                            {
                                headerCol.RelativeColumn();
                            }
                        });

                        // Table Header with Styling
                        table.Header(header =>
                        {
                            foreach (var col in columns)
                            {
                                var cell = header.Cell().DefaultHeaderCellStyle();
                                cell.Text(col.Title).SemiBold();
                            }
                        });

                        // Table Rows with Data
                        foreach (var item in data)
                        {
                            foreach (var column in columns)  //foreach (var prop in properties)
                            {
                                var propertyInfo = properties.FirstOrDefault(p => p.Property.Name == column.Name)?.Property;
                                var rawValue = propertyInfo?.GetValue(item);

                                var cell = table.Cell().DefaultBodyCellStyle();
                                // Check if it's the "Active" column (Assuming "IsActive" property)
                                if (column.Name == "IsActive" && rawValue is bool boolValue)
                                {
                                    var text = boolValue ? "✅" : "❌";
                                    cell.AlignCenter().AlignMiddle().Text(text).FontColor(Colors.Red.Medium);
                                }
                                else if (rawValue is DateTime dateValue)  // Safe cast to DateTime
                                {
                                    cell.Text(dateValue.ToString(dateFormatData));
                                }
                                else
                                {
                                    cell.Text(rawValue);
                                }
                            }
                        }
                    });

                    // Footer with Logo & Contact Info
                    page.Footer().BorderTop(1).BorderColor(Colors.Grey.Darken2).PaddingVertical(5).Row(footer =>
                    {
                        //Left side
                        footer.RelativeItem().Row(content =>
                        {
                            content.AutoItem().Height(20).Image(logoPath); // Logo with auto width
                            content.AutoItem().AlignMiddle().Text(logoText).SemiBold(); // Text with auto width
                        });
                        //Center
                        footer.RelativeItem().AlignCenter().Text(text =>
                        {
                            text.DefaultTextStyle(x => x.FontColor(Colors.Grey.Darken1));
                            text.Span("Page ");
                            text.CurrentPageNumber();
                            text.Span(" of ");
                            text.TotalPages();
                        });
                        //Right side
                        footer.RelativeItem().AlignRight().Text(supportContact);
                    });
                });
            });

            var pdfBytes = document.GeneratePdf();
            string fileName = StringHelper.ConvertReportTitleToFileName(reportTitle, "pdf");
            // Set response headers
            var response = _httpContextAccessor.HttpContext.Response;
            response.Headers["X-Filename"] = fileName;
            response.Headers["Content-Disposition"] = "attachment; filename=" + fileName;

            return new FileContentResult(pdfBytes, pdfContentType);
        }


    }
}
