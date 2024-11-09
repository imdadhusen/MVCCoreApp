using HisabPro.DTO.Response;

namespace HisabPro.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<IdNameRes>> GetParentCategoriesAsync();
        Task<List<ChildCategoryRes>> GetChildCategoriesAsync();
    }
}
