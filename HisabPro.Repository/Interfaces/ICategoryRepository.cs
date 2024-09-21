using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;

namespace HisabPro.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<ParentCategoryRes>> GetParentCategories();
        Task<List<ChildCategoryRes>> GetChildCategories();
        Task<List<CategoryListRes>> GetCategories();
        Task<ResponseDTO<ChildCategoryRes>> SaveCategory(SaveCategoryDTO req);
        Task<ResponseDTO<bool>> Delete(DeleteCategoryDTO req);
    }
}
