using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.DTO.Model;

namespace HisabPro.Services.Interfaces
{
    public interface IAccountService
    {
        Task<SaveAccountReq> GetByIdAsync(int id);
        Task<ResponseDTO<List<AccountRes>>> GetAll();
        Task<PageDataRes<AccountRes>> PageData(LoadDataRequest request);
        Task<PageDataRes<AccountRes>> ExportData(ExportReq request);
        Task<ResponseDTO<AccountRes>> SaveAsync(SaveAccountReq req);
        Task<ResponseDTO<bool>> DeleteAsync(int id);

        Task<List<IdNameRes>> GetAccountsAsync();
    }
}
