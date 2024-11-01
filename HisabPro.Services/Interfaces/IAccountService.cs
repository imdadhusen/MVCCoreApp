using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.DTO.Model;

namespace HisabPro.Services.Interfaces
{
    public interface IAccountService
    {
        Task<SaveAccount> GetByIdAsync(int id);
        Task<ResponseDTO<List<AccountResponse>>> GetAll();
        Task<ResponseDTO<AccountResponse>> Save(SaveAccount req);
    }
}
