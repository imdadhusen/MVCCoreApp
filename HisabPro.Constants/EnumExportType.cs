using HisabPro.Constants.Resources;

namespace HisabPro.Constants
{
    public enum EnumExportType
    {
        [EnumText(ResourceKey.LabelExportPDF)]
        PDF = 1,
        [EnumText(ResourceKey.LabelExportExcel)]
        Excel = 2,
        [EnumText(ResourceKey.LabelExportHTML)]
        HTML = 3,
        [EnumText(ResourceKey.LabelExportCSV)]
        CSV = 4
    }

    public class ExportIcons
    {
        public const string PDF = "fa-file-pdf";
        public const string Excel = "fa-file-excel";
        public const string HTML = "fa-file-code";
        public const string CSV = "fa-file-csv";

        public static string GetIconById(EnumExportType exportIcon)
        {
            if (exportIcon == EnumExportType.PDF)
                return PDF;
            if (exportIcon == EnumExportType.Excel)
                return Excel;
            if (exportIcon == EnumExportType.HTML)
                return HTML;
            return CSV;
        }
    }
}
