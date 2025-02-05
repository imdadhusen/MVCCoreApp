using AutoMapper;
using HisabPro.Common;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.IEntities;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Helper;
using HisabPro.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Category = HisabPro.Entities.Models.Category;

namespace HisabPro.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CategoryService(IRepository<Category> categoryRepo, IMapper mapper, IUserContext userContext)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<SaveCategoryReq> GetByIdAsync(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            var map = _mapper.Map<SaveCategoryReq>(category);
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
            return new ResponseDTO<List<CategoryRes>>(System.Net.HttpStatusCode.OK, SharedResource.LabelApiDataRetrived, map);
        }
        public async Task<PageDataRes<CategoryRes>> PageData(LoadDataRequest request)
        {
            var data = _categoryRepo.GetAllDataWithSelfRefAsync(p => p.ParentId == null, "SubCategories");
            data = data.ApplyDynamicFilters(request.Filters);
            data = PageDataHelper.ApplySort(data, request.PageData);
            var mappedData = _mapper.Map<List<CategoryRes>>(data);
            return new PageDataRes<CategoryRes> { Data = mappedData };
        }
        public async Task<ResponseDTO<CategoryRes>> SaveAsync(SaveCategoryReq req)
        {
            var categories = await _categoryRepo.GetAll()
                .Where(c => c.Type == req.Type && (c.IsStandard == true || c.CreatedBy == _userContext.GetCurrentUserId(false)))
                .Select(c => c)
                .ToListAsync();

            var duplicates = Exists(categories, req.Name, req.Id);
            if (duplicates.Count >= 1)
            {
                if (duplicates[0].IsStandard)
                {
                    throw new CustomValidationException(SharedResource.LabelApiSameNameInStandardCategory);
                }
                else
                {
                    throw new CustomValidationException(SharedResource.LabelApiDataWithSameName);
                }
            }

            var category = _mapper.Map<Category>(req);
            var result = await _categoryRepo.SaveAsync(category);
            var map = _mapper.Map<CategoryRes>(result);
            return new ResponseDTO<CategoryRes>(System.Net.HttpStatusCode.OK, SharedResource.LabelApiSave, map);
        }

        public async Task<ResponseDTO<bool>> DeleteAsync(int id)
        {
            var result = await _categoryRepo.DeleteAsync(id);
            if (result)
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.OK, SharedResource.LabelApiDelete, result);
            }
            else
            {
                return new ResponseDTO<bool>(System.Net.HttpStatusCode.BadRequest, SharedResource.LabelApiNotFound, result);
            }
        }

        public async Task<List<IdNameRes>> GetCategoriesAsync(EnumCategoryType? categoryType)
        {
            IQueryable<Category> query = _categoryRepo.GetAll().Where(c => c.ParentId == null);
            if (categoryType != null)
            {
                query = query.Where(c => c.Type == (int)categoryType);
            }
            return await query.Select(c => new IdNameRes { Id = c.Id.ToString(), Name = c.Name })
                    .ToListAsync();
        }

        public async Task<List<SubCategoryRes>> GetSubCategoriesAsync(EnumCategoryType? categoryType)
        {
            IQueryable<Category> query = _categoryRepo.GetAll().Where(c => c.ParentId != null);
            if (categoryType != null)
            {
                query = query.Where(c => c.Type == (int)categoryType);
            }
            return await query.Select(c => new SubCategoryRes { Id = c.Id, Name = c.Name, CategoryId = c.ParentId.Value })
                    .ToListAsync();
        }

        private List<Category> Exists(List<Category> categories, string name, int? id = null)
        {
            if (id.HasValue)
            {
                return categories.Where(c => c.Name == name && c.Id != id.Value).ToList();
            }
            return categories.Where(c => c.Name == name).ToList();
        }
    }
}
