using HisabPro.DTO.Request;

namespace HisabPro.Web.Helper
{
    public static class ExportDataHelper
    {
        public static async Task<T> GetData<T>(ExportReq req, Func<ExportReq, Task<T>> fetchExportData)
        {
            var exportData = await fetchExportData(req);
            return exportData;
        }
    }
}
