using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;

namespace HisabPro.Services.Interfaces
{
    public interface IIncomeService
    {
        Task<SaveIncome> GetByIdAsync(int id);
        Task<ResponseDTO<List<IncomeResponse>>> GetAll();
        Task<PageDataRes<IncomeResponse>> PageData(PageDataReq request);

        Task<ResponseDTO<IncomeResponse>> Save(SaveIncome req);
        Task<ResponseDTO<bool>> DeleteAsync(int id);
    }
}
