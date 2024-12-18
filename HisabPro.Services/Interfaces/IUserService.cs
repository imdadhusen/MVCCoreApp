using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.DTO.Model;

namespace HisabPro.Services.Interfaces
{
    public interface IUserService
    {
        Task<SaveUserReq> GetByIdAsync(int id);
        Task<ResponseDTO<List<UserResponse>>> GetAll();
        Task<PageDataRes<UserResponse>> PageData(LoadDataRequest request);
        Task<ResponseDTO<UserResponse>> SaveAsync(SaveUserReq req);
        Task<ResponseDTO<bool>> DeleteAsync(int id);
    }
}
