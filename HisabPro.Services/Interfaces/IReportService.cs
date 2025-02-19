using HisabPro.DTO.Request;
using HisabPro.DTO.Response;

namespace HisabPro.Services.Interfaces
{
    public interface IReportService
    {
        Task<PageDataRes<ReportRes>> PageData(LoadDataRequest request);
    }
}
