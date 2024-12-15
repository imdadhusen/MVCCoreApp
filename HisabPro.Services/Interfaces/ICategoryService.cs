using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;

namespace HisabPro.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ResponseDTO<List<CategoryRes>>> GetAll();
        Task<PageDataRes<CategoryRes>> PageData(LoadDataRequest request);

        Task<List<IdNameRes>> GetParentCategoriesAsync();
        Task<List<ChildCategoryRes>> GetChildCategoriesAsync();
    }
}
