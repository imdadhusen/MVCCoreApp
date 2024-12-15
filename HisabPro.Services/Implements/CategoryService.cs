using AutoMapper;
using HisabPro.DTO.Model;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Interfaces;
using HisabPro.Constants;
using HisabPro.DTO.Request;
using HisabPro.Services.Helper;

namespace HisabPro.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        private readonly IRepository<ParentCategory> _parentCategoryRepo;
        private readonly IRepository<ChildCategory> _childCategoryRepo;

        public CategoryService(IRepository<Category> categoryRepo, IMapper mapper, IRepository<ParentCategory> parentCategoryRepo, IRepository<ChildCategory> childCategoryRepo)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _parentCategoryRepo = parentCategoryRepo;
            _childCategoryRepo = childCategoryRepo;
        }

        public async Task<ResponseDTO<List<CategoryRes>>> GetAll()
        {
            var categories = await _categoryRepo.GetAllAsync();
            var map = _mapper.Map<List<CategoryRes>>(categories);
            return new ResponseDTO<List<CategoryRes>>() { Message = AppConst.ApiMessage.DataRetrived, Response = map, StatusCode = System.Net.HttpStatusCode.OK };
        }
        public async Task<PageDataRes<CategoryRes>> PageData(LoadDataRequest request)
        {
            var data = _categoryRepo.GetAllDataWithSelfRefAsync(p => p.ParentId == null, "SubCategories");
            data = data.ApplyDynamicFilters(request.Filters);
            data = PageDataHelper.ApplySort(data, request.PageData);
            var mappedData = _mapper.Map<List<CategoryRes>>(data);
            return new PageDataRes<CategoryRes> { Data = mappedData };
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
