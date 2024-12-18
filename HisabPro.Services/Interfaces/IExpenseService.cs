using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;

namespace HisabPro.Services.Implements
{
    public interface IExpenseService
    {
        Task<SaveExpenseReq> GetByIdAsync(int id);
        Task<ResponseDTO<List<ExpenseRes>>> GetAll();
        Task<ResponseDTO<ExpenseRes>> SaveAsync(SaveExpenseReq req);
        Task<ResponseDTO<DataImportRes>> AddRangeAsync(IEnumerable<SaveExpenseReq> expenses);
        Task<ResponseDTO<bool>> DeleteAsync(int id);

        Task<PageDataRes<ExpenseRes>> PageData(LoadDataRequest request);
    }
}
