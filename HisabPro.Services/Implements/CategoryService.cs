using AutoMapper;
using HisabPro.Constants;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
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

        public CategoryService(UpdateRepository<Category, CategoryRes> updateRepo, IRepository<Category> categoryRepo, IMapper mapper)
        {
            _updateRepo = updateRepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
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

        public async Task<List<IdNameRes>> GetParentCategoriesAsync(EnumCategoryType? categoryType)
        {
            IQueryable<Category> query = _categoryRepo.GetAll().Where(c => c.ParentId == null);
            if (categoryType != null)
            {
                query = query.Where(c => c.Type == (int)categoryType);
            }
            return await query.Select(c => new IdNameRes { Id = c.Id.ToString(), Name = c.Name })
                    .ToListAsync();
        }

        public async Task<List<ChildCategoryRes>> GetChildCategoriesAsync(EnumCategoryType? categoryType)
        {
            IQueryable<Category> query = _categoryRepo.GetAll().Where(c => c.ParentId != null);
            if (categoryType != null)
            {
                query = query.Where(c => c.Type == (int)categoryType);
            }
            return await query.Select(c => new ChildCategoryRes { Id = c.Id, Name = c.Name, ParentCategoryId = c.ParentId.Value })
                    .ToListAsync();
        }
    }
}
