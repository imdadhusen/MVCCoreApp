namespace HisabPro.Common
{
    public static class StringHelper
    {
        public static string GetActionFromUrl(string? url)
        {
            var title = url?.Split('/').LastOrDefault();
            return title ?? string.Empty;
        }
    }
}
