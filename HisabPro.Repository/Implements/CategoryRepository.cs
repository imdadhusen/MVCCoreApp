using AutoMapper;
using HisabPro.Constants;
using HisabPro.DTO.Model;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HisabPro.Repository.Implements
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDTO<CategoryListWithChild>> CategoriesWithChilds()
        {
            var response = new ResponseDTO<CategoryListWithChild>() { StatusCode = HttpStatusCode.OK };
            try
            {
                CategoryListWithChild categoryDetail = new CategoryListWithChild
                {
                    AllCategoryList = await GetCategories(),
                    ParentCategoryList = await GetParentCategories(),
                    ChildCategoryList = await GetChildCategories()
                };
                response.Message = AppConst.ApiMessage.DataRetrived;
                response.Response = categoryDetail;
            }
            catch (Exception)
            {
                response.Message = AppConst.ApiMessage.DataRetrivedFailed;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }
        public async Task<ResponseDTO<ChildCategoryRes>> SaveCategory(SaveCategoryDTO req)
        {
            if (req.ParentId.HasValue && req.ParentId.Value > 1)
            {
                //Save in child category
                return await Save(req, _context.ChildCategories);
            }
            else
            {
                //Save in parent category
                return await Save(req, _context.ParentCategories);
            }
        }
        public async Task<ResponseDTO<bool>> Delete(DeleteCategoryDTO req)
        {
            if (req.ParentId == null)
            {
                return await Delete(req, _context.ParentCategories);
            }
            else
            {
                return await Delete(req, _context.ChildCategories);
            }
        }

        private async Task<List<CategoryListRes>> GetCategories()
        {
            var categoryList = await _context.ParentCategories
                 .Include(c => c.ChildCategories)
                 .AsNoTracking()
                 .OrderBy(c => c.Name)
                 .ToListAsync();
            return _mapper.Map<List<CategoryListRes>>(categoryList);
        }
        private async Task<List<ParentCategoryRes>> GetParentCategories()
        {
            var categoryList = await _context.ParentCategories
                 .AsNoTracking()
                 .ToListAsync();
            return _mapper.Map<List<ParentCategoryRes>>(categoryList);
        }
        private async Task<List<ChildCategoryRes>> GetChildCategories()
        {
            var categoryList = await _context.ChildCategories
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<ChildCategoryRes>>(categoryList);
        }
        private async Task<ResponseDTO<ChildCategoryRes>> Save<TCategory>(SaveCategoryDTO req, DbSet<TCategory> dbSet)
    where TCategory : class, ICategorySave, new()
        {
            var response = new ResponseDTO<ChildCategoryRes>();
            response.StatusCode = HttpStatusCode.OK;
            try
            {
                TCategory? category;
                if (req.Id > 0)
                {
                    // Check for duplicate category name
                    var categories = await dbSet.Where(c => c.Name.Trim() == req.Name.Trim() || c.Id == req.Id).ToListAsync();
                    var dupCategory = categories.Where(c => c.Id != req.Id && c.Name.Trim() == req.Name.Trim()).FirstOrDefault();
                    if (dupCategory != null)
                    {
                        throw new Exception(AppConst.ApiMessage.DataWithSameName);
                    }
                    else
                    {
                        category = categories.Where(c => c.Id == req.Id).FirstOrDefault();
                        if (category != null)
                        {
                            category.Name = req.Name;
                            // Check if it's a ChildCategory and assign ParentId
                            if (category is ChildCategory childCategory && req.ParentId.HasValue)
                            {
                                childCategory.ParentCategoryId = req.ParentId.Value;
                            }
                            dbSet.Update(category);
                        }
                        else
                        {
                            throw new Exception(AppConst.ApiMessage.NotFound);
                        }
                    }
                }
                else
                {
                    // Check for duplicate category name
                    var dupCategory = await dbSet.Where(c => c.Name.Trim() == req.Name.Trim()).FirstOrDefaultAsync();
                    if (dupCategory != null)
                    {
                        throw new Exception(AppConst.ApiMessage.DataWithSameName);
                    }
                    else
                    {
                        // Create new category
                        category = new TCategory() { Name = req.Name };
                        // Check if it's a ChildCategory and assign ParentId
                        if (category is ChildCategory childCategory && req.ParentId.HasValue)
                        {
                            childCategory.ParentCategoryId = req.ParentId.Value;
                        }
                        dbSet.Add(category);
                    }
                }
                await _context.SaveChangesAsync();
                var data = new ChildCategoryRes { Id = category.Id, Name = category.Name, ParentCategoryId = (req.ParentId == null) ? 0 : req.ParentId.Value };
                response.Message = AppConst.ApiMessage.Save;
                response.Response = data;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = AppConst.ApiMessage.InternalError;
            }
            return response;
        }
        private async Task<ResponseDTO<bool>> Delete<T>(DeleteCategoryDTO req, DbSet<T> dbSet) where T : class, ICategoryDelete
        {
            var response = new ResponseDTO<bool>();
            response.StatusCode = HttpStatusCode.OK;
            try
            {
                var category = await dbSet.Where(c => c.Id == req.Id).FirstOrDefaultAsync();
                if (req.ParentId != null && category is ChildCategory childCategory)
                {
                    // Check if it's a ChildCategory and assign ParentId
                    if (childCategory.ParentCategoryId != req.ParentId.Value)
                    {
                        category = null;
                    }
                }
                if (category != null)
                {
                    dbSet.Remove(category);
                    await _context.SaveChangesAsync();
                    response.Message = AppConst.ApiMessage.Delete;
                    response.Response = true;
                }
                else
                {
                    response.Message = AppConst.ApiMessage.NotFound;
                    response.Response = false;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.ToUpper().Contains("REFERENCE CONSTRAINT"))
                {
                    response.Message = AppConst.ApiMessage.ReferenceDeleteError;
                }
                else
                {
                    response.Message = AppConst.ApiMessage.InternalError;
                }
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Response = false;
            }
            return response;
        }
    }
}
