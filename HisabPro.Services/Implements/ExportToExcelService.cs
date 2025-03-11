using ClosedXML.Excel;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using HisabPro.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HisabPro.Services.Implements
{
    public class ExportToExcelService : IExportService
    {
        private readonly ISharedViewLocalizer _localizer;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExportToExcelService(IHttpContextAccessor httpContextAccessor, ISharedViewLocalizer localizer)
        {
            _httpContextAccessor = httpContextAccessor;
            _localizer = localizer;
        }

        public FileContentResult Export<T>(List<T> data, string reportTitle, string reportFileName, List<DTO.Model.Column> columns, string AppliedSortField = "NA", string AppliedSortType = "NA", int AppliedFilterCount = 0)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Report");
                int row = 1;

                worksheet.Range(1, 1, 5 + data.Count, columns.Count).Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);

                // Header Section
                var cellDateTitle = worksheet.Cell(row, 1);
                cellDateTitle.Value = $"{_localizer.Get(ResourceKey.ReportDate).Value}\n{DateTime.Now.ToString(ExportReportValues.DateFormatHeader)}";
                cellDateTitle.Style.Alignment.WrapText = true; // Enable text wrapping

                var cellReportTitle = worksheet.Cell(row, 2);
                cellReportTitle.Value = reportTitle;
                var cellReportTitleRange = worksheet.Range(row, 2, row, columns.Count - 1);
                cellReportTitleRange.Merge().Style
                .Font.SetBold(true)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                var cellSortAndFilter = worksheet.Cell(row, columns.Count);
                cellSortAndFilter.Value = $"{string.Format(_localizer.Get(ResourceKey.ReportAppliedSort), AppliedSortField, AppliedSortType)}\n{string.Format(_localizer.Get(ResourceKey.ReportAppliedFilter), AppliedFilterCount)}";

                //Empty row for separator
                worksheet.Range(row + 1, 1, row + 1, columns.Count).Merge();
                row += 2;

                // Column Headers
                for (int i = 0; i < columns.Count; i++)
                {
                    var cellHeader = worksheet.Cell(row, i + 1);
                    cellHeader.Value = columns[i].Title;
                    cellHeader.Style.Font.Bold = true;
                    cellHeader.Style.Fill.BackgroundColor = XLColor.LightGray;
                    cellHeader.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    cellHeader.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    switch (columns[i].Align)
                    {
                        case Align.Center:
                            cellHeader.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            break;
                        case Align.Right:
                            cellHeader.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            break;
                    }
                }
                row++;

                // Data Rows
                foreach (var item in data)
                {
                    AddRowWithChildren(worksheet, row, columns, item, 0);
                    row++;
                }

                // Footer Section
                //Empty row for separator
                worksheet.Range(row, 1, row, columns.Count).Merge();
                row++;
                worksheet.Cell(row, 1).Value = string.Format("{0} | {1}", ExportReportValues.LogoText, ExportReportValues.SupportContact);

                worksheet.Range(row, 1, row, columns.Count).Merge().Style
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                .Font.SetBold();


                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    string fileName = $"{reportFileName}.xlsx";
                    var response = _httpContextAccessor.HttpContext.Response;
                    response.Headers["X-Filename"] = fileName;
                    response.Headers["Content-Disposition"] = "attachment; filename=" + fileName;
                    response.Headers["Content-Type"] = ExportReportValues.ExcelContentType;

                    byte[] fileBytes = stream.ToArray(); // Convert to byte array
                    return new FileContentResult(fileBytes, ExportReportValues.ExcelContentType)
                    {
                        FileDownloadName = fileName
                    };
                }
            }
        }

        private void AddRowWithChildren<T>(IXLWorksheet worksheet, int row, List<DTO.Model.Column> columns, T parentRow, int level)
        {
            var childProperty = parentRow.GetType().GetProperty("SubCategories");
            var childRows = childProperty?.GetValue(parentRow) as IEnumerable<object>;
            bool hasChildren = childRows?.Any() == true;

            for (int i = 0; i < columns.Count; i++)
            {
                var propertyInfo = parentRow.GetType().GetProperty(columns[i].Name);
                var rawValue = propertyInfo?.GetValue(parentRow);

                var cell = worksheet.Cell(row, i + 1);
                if (columns[i].Name == "Name")
                    cell.Value = new string(' ', level * 4) + (rawValue?.ToString() ?? "");
                else if (columns[i].Name == "IsActive" && rawValue is bool boolValue)
                    cell.Value = boolValue ? ExportReportValues.TickMarkText : ExportReportValues.CrossMarkText;
                else if (rawValue is DateTime dateValue)
                    cell.Value = dateValue.ToString(ExportReportValues.DateFormatData);
                else
                    cell.Value = rawValue?.ToString() ?? "";
                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                cell.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                switch (columns[i].Align)
                {
                    case Align.Center:
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        break;
                    case Align.Right:
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        break;
                }
            }

            if (hasChildren)
            {
                foreach (var childRow in childRows)
                {
                    row++;
                    AddRowWithChildren(worksheet, row, columns, childRow, level + 1);
                }
            }
        }
    }
}
