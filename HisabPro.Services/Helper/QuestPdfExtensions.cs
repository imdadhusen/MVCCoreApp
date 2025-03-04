using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace HisabPro.Services.Helper
{
    public static class QuestPdfExtensions
    {
        public static IContainer DefaultHeaderCellStyle(this IContainer container)
        {
            return container.Background(Colors.Grey.Lighten1).Border(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignLeft();
        }

        public static IContainer DefaultBodyCellStyle(this IContainer container)
        {
            return container.Border(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignLeft();
        }
    }
}
