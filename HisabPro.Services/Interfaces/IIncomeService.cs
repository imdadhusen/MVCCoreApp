using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;

namespace HisabPro.Services.Interfaces
{
    public interface IIncomeService
    {
        Task<SaveIncomeReq> GetByIdAsync(int id);
        Task<ResponseDTO<List<IncomeRes>>> GetAll();
        Task<PageDataRes<IncomeRes>> PageData(LoadDataRequest request);
        Task<ResponseDTO<DataImportRes>> AddRangeAsync(IEnumerable<SaveIncomeReq> incomes);
        Task<ResponseDTO<IncomeRes>> SaveAsync(SaveIncomeReq req);
        Task<ResponseDTO<bool>> DeleteAsync(int id);
    }
}
