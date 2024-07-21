using HisabPro.DTO.Response;

namespace HisabPro.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<ParentCategoryRes>> GetParentCategories();
        Task<List<ChildCategoryRes>> GetChildCategories();
        Task<List<CategoryListRes>> GetCategories();
    }
}
