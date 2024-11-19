using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Interfaces;

namespace HisabPro.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<ParentCategory> _parentCategoryRepo;
        private readonly IRepository<ChildCategory> _childCategoryRepo;

        public CategoryService(IRepository<ParentCategory> parentCategoryRepo, IRepository<ChildCategory> childCategoryRepo)
        {
            _parentCategoryRepo = parentCategoryRepo;
            _childCategoryRepo = childCategoryRepo;
        }

        public async Task<List<IdNameRes>> GetParentCategoriesAsync()
        {
            return await _parentCategoryRepo.GetAllAsync(a => new IdNameRes { Id = a.Id.ToString(), Name = a.Name });
        }

        public async Task<List<ChildCategoryRes>> GetChildCategoriesAsync()
        {
            return await _childCategoryRepo.GetAllAsync(a => new ChildCategoryRes { Id = a.Id, Name = a.Name, ParentCategoryId = a.ParentCategoryId });
        }
    }
}
