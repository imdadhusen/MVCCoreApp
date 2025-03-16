namespace HisabPro.Common
{
    public static class StringHelper
    {
        public static string GetActionFromUrl(string? url)
        {
            var title = url?.Split('/').LastOrDefault();
            return title ?? string.Empty;
        }

        public static string ConvertReportTitleToFileName(string title, string extension)
        {
            return $"{title.Replace(" ", "_")}.{extension}";
        }

        
    }
}
