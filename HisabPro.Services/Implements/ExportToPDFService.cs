﻿using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using HisabPro.Services.Helper;
using HisabPro.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection;

namespace HisabPro.Services.Implements
{
    public class ExportToPDFService : IExportService
    {
        private readonly ISharedViewLocalizer _localizer;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExportToPDFService(IHttpContextAccessor httpContextAccessor, ISharedViewLocalizer localizer)
        {
            _httpContextAccessor = httpContextAccessor;
            _localizer = localizer;
        }

        public FileContentResult Export<T>(List<T> data, string reportTitle, string reportFileName, List<Column> columns, List<FilterDescriptionModel>? filterDescriptions, string AppliedSortField = "NA", string AppliedSortType = "NA")
        {
            QuestPDF.Settings.License = LicenseType.Community;

            // Get properties with Display Names
            var properties = typeof(T).GetProperties().Where(p => p.CanRead).Select(p => new { Property = p }).ToList();

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
                            col.Item().Text(_localizer.Get(ResourceKey.ReportDate)).SemiBold();
                            col.Item().Text(DateTime.Now.ToString(ExportReportValues.DateFormatHeader)).FontColor(Colors.Grey.Darken2); // Value below (lighter)
                        });

                        // Center: Report Title
                        header.RelativeItem().AlignCenter().Text(reportTitle).FontSize(14).SemiBold().FontColor(Colors.Blue.Darken3);

                        // Right: For Applied Sort and Fiter
                        header.RelativeItem().AlignRight().Column(col =>
                        {
                            col.Item().Text(string.Format(_localizer.Get(ResourceKey.ReportAppliedSort), AppliedSortField, AppliedSortType));
                            col.Item().Text(string.Format(_localizer.Get(ResourceKey.ReportAppliedFilter), filterDescriptions?.Count));
                        });
                    });

                    // Table Content
                    page.Content().PaddingTop(5)
                    .Column(column =>
                    {
                        if (filterDescriptions != null && filterDescriptions.Count >= 1)
                        {
                            // First Table: Applied Filter
                            column.Item().Table(filterTable =>
                            {
                                // Define two columns (20% and remaining width)
                                filterTable.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(100); // Approx 20% width
                                    columns.RelativeColumn(); // Remaining width
                                });

                                // Header Row with Background Color
                                filterTable.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Background(Colors.Grey.Lighten3).Padding(4).Text(_localizer.Get(ResourceKey.ReportFilterDescription)).Bold();
                                });

                                // Add Filter Rows
                                foreach (var filter in filterDescriptions)
                                {
                                    filterTable.Cell().Padding(3).Text(filter.FilterName).Bold();
                                    filterTable.Cell().Padding(3).Text(filter.Description);
                                }
                            });
                            // Space between tables
                            column.Item().PaddingVertical(10);
                        }

                        // Second Table: Grid Data
                        column.Item().Table(table =>
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
                                    switch (col.Align)
                                    {
                                        case Align.Center:
                                            cell.AlignCenter();
                                            break;
                                        case Align.Right:
                                            cell.AlignRight();
                                            break;
                                    }
                                    cell.Text(col.Title).SemiBold();
                                }
                            });

                            // Table Rows with Data
                            foreach (var item in data)
                            {
                                AddRowWithChildren(table, properties.Select(p => p.Property).ToList(), item, columns, 0);
                            }
                        });
                    });

                    // Footer with Logo & Contact Info
                    page.Footer().BorderTop(1).BorderColor(Colors.Grey.Darken2).PaddingVertical(5).Row(footer =>
                    {
                        //Left side
                        footer.RelativeItem().Row(content =>
                        {
                            content.AutoItem().Height(20).Image(ExportReportValues.LogoPath); // Logo with auto width
                            content.AutoItem().AlignMiddle().Text(ExportReportValues.LogoText).SemiBold(); // Text with auto width
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
                        footer.RelativeItem().AlignRight().Text(ExportReportValues.SupportContact);
                    });
                });
            });

            var pdfBytes = document.GeneratePdf();
            string fileName = string.Format("{0}.pdf", reportFileName); //StringHelper.ConvertReportTitleToFileName(reportTitle, "pdf");
            // Set response headers
            var response = _httpContextAccessor.HttpContext.Response;
            response.Headers["X-Filename"] = fileName;
            response.Headers["Content-Disposition"] = "attachment; filename=" + fileName;
            response.Headers["Content-Type"] = ExportReportValues.PdfContentType;

            return new FileContentResult(pdfBytes, ExportReportValues.PdfContentType)
            {
                FileDownloadName = fileName
            };
        }

        // Helper method for hierarchical data (Parent-Child Rows)
        void AddRowWithChildren(TableDescriptor table, List<PropertyInfo> properties, object parentRow, List<Column> columns, int level)
        {
            var childProperty = parentRow.GetType().GetProperty("SubCategories");
            var childRows = childProperty?.GetValue(parentRow) as IEnumerable<object>;
            bool hasChildren = childRows?.Any() == true; // Check if row has children

            var backgroundColor = hasChildren ? Colors.Grey.Lighten3 : Colors.White; // Highlight only true parent rows

            foreach (var column in columns)
            {
                var propertyInfo = properties.FirstOrDefault(p => p.Name == column.Name);
                var rawValue = propertyInfo?.GetValue(parentRow);

                // Apply background to full cell, Apply default styles (including left alignment)
                var cell = table.Cell().Background(backgroundColor).DefaultBodyCellStyle();
                switch (column.Align)
                {
                    case Align.Center:
                        cell.AlignCenter();
                        break;
                    case Align.Right:
                        cell.AlignRight();
                        break;
                }

                if (column.Name == "Name") // Indent child rows
                {
                    cell.Text(text => text.Span(new string(' ', level * 4) + (rawValue?.ToString() ?? "")));
                }
                else if (column.Name == "IsActive" && rawValue is bool boolValue)
                {
                    cell.Text(text => text.Span(boolValue ? ExportReportValues.TickMarkText : ExportReportValues.CrossMarkText));//.FontColor(Colors.Red.Medium);
                }
                else if (rawValue is DateTime dateValue)
                {
                    cell.Text(text => text.Span(dateValue.ToString(ExportReportValues.DateFormatData)));
                }
                else
                {
                    cell.Text(text => text.Span(rawValue?.ToString() ?? ""));
                }
            }

            // Recursively render child rows if present
            if (hasChildren)
            {
                foreach (var childRow in childRows)
                {
                    AddRowWithChildren(table, properties, childRow, columns, level + 1);
                }
            }
        }
    }
}
