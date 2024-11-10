using OfficeOpenXml;

namespace HisabPro.Web.Helper
{
    public class ExcelService
    {
        public List<string[]> ReadExcelFile(string filePath)
        {
            var data = new List<string[]>();

            // Load and read the Excel file
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Load the first worksheet
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                for (int row = 1; row <= rowCount; row++)
                {
                    var rowData = new string[colCount];
                    for (int col = 1; col <= colCount; col++)
                    {
                        rowData[col - 1] = worksheet.Cells[row, col].Text; // Read cell value
                    }
                    data.Add(rowData);
                }
            }

            return data;
        }
    }
}
