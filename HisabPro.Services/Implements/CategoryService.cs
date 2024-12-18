using AutoMapper;
using HisabPro.Constants;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Helper;
using HisabPro.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Category = HisabPro.Entities.Models.Category;

namespace HisabPro.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly UpdateRepository<Category, CategoryRes> _updateRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        //TODO: This need to be get from Category table not Parent and Child tables
        private readonly IRepository<ParentCategory> _parentCategoryRepo;
        private readonly IRepository<ChildCategory> _childCategoryRepo;

        public CategoryService(UpdateRepository<Category, CategoryRes> updateRepo, IRepository<Category> categoryRepo, IMapper mapper,
            IRepository<ParentCategory> parentCategoryRepo, IRepository<ChildCategory> childCategoryRepo)
        {
            _updateRepo = updateRepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;

            _parentCategoryRepo = parentCategoryRepo;
            _childCategoryRepo = childCategoryRepo;
        }

        public async Task<SaveCategory> GetByIdAsync(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            var map = _mapper.Map<SaveCategory>(category);
            return map;
        }
        public async Task<List<IdNameAndRefId>> GetAllParentCategoryByType(int type)
        {
            var categories = await _categoryRepo.GetAll().Where(c => c.Type == type && c.ParentId == null).ToListAsync();
            var map = _mapper.Map<List<IdNameAndRefId>>(categories);
            return map;
        }

        public async Task<ResponseDTO<List<CategoryRes>>> GetAll()
        {
            var categories = await _categoryRepo.GetAllAsync();
            var map = _mapper.Map<List<CategoryRes>>(categories);
            return new ResponseDTO<List<CategoryRes>>(System.Net.HttpStatusCode.OK, AppConst.ApiMessage.DataRetrived, map);
        }
        public async Task<PageDataRes<CategoryRes>> PageData(LoadDataRequest request)
        {
            var data = _categoryRepo.GetAllDataWithSelfRefAsync(p => p.ParentId == null, "SubCategories");
            data = data.ApplyDynamicFilters(request.Filters);
            data = PageDataHelper.ApplySort(data, request.PageData);
            var mappedData = _mapper.Map<List<CategoryRes>>(data);
            return new PageDataRes<CategoryRes> { Data = mappedData };
        }
        public async Task<ResponseDTO<CategoryRes>> SaveAsync(SaveCategory req)
        {
            var map = _mapper.Map<Category>(req);
            //TODO : Category should not duplicate within Standard and User Created (own). User can create same category as per other user
            var result = await _updateRepo.SaveAsync(map, req.Name, req.Id);
            return new ResponseDTO<CategoryRes>(System.Net.HttpStatusCode.OK, AppConst.ApiMessage.Save, result);
        }

        public async Task<ResponseDTO<bool>> DeleteAsync(int id)
        {
            var result = await _categoryRepo.DeleteAsync(id);
            if (result)
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.OK, AppConst.ApiMessage.Delete, result);
            }
            else
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.BadRequest, AppConst.ApiMessage.NotFound, result);
            }
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
