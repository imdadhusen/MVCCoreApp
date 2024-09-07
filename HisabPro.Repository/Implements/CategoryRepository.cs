using AutoMapper;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HisabPro.Repository.Implements
{
    public class CategoryRepository(ApplicationDbContext context, IMapper mapper) : ICategoryRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<List<CategoryListRes>> GetCategories()
        {
            var categoryList = await _context.ParentCategories
                 .Include(c => c.ChildCategories)
                 .AsNoTracking()
                 .OrderBy(c => c.Name)
                 .ToListAsync();
            return _mapper.Map<List<CategoryListRes>>(categoryList);
        }

        public async Task<List<ParentCategoryRes>> GetParentCategories()
        {
            var categoryList = await _context.ParentCategories
                 .AsNoTracking()
                 .ToListAsync();
            return _mapper.Map<List<ParentCategoryRes>>(categoryList);
        }

        public async Task<List<ChildCategoryRes>> GetChildCategories()
        {
            var categoryList = await _context.ChildCategories
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<ChildCategoryRes>>(categoryList);
        }

        public async Task<ChildCategoryRes> SaveCategory(SaveRequestDTO req)
        {
            try
            {
                ChildCategoryRes? category;
                if (req.ParentId.HasValue && req.ParentId.Value > 1)
                {
                    //Save in child category
                    category = await SaveChildCategory(req);
                }
                else
                {
                    //Save in parent category
                    category = await SaveParentCategory(req);
                }
                return category;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<ChildCategoryRes> SaveParentCategory(SaveRequestDTO req)
        {
            ParentCategory? category;
            if (req.Id > 0)
            {
                // Check for duplicate category name
                var categories = await _context.ParentCategories.Where(c => c.Name == req.Name || c.Id == req.Id).ToListAsync();
                var dupCategory = categories.Where(c => c.Id != req.Id && c.Name == req.Name).FirstOrDefault();
                if (dupCategory != null)
                {
                    throw new Exception("Category with this name already exists");
                }
                else
                {
                    category = categories.Where(c => c.Id == req.Id).FirstOrDefault();
                    if (category != null)
                    {
                        category.Name = req.Name;
                        _context.ParentCategories.Update(category);
                    }
                    else
                    {
                        throw new Exception("Provided category id does not exists");
                    }
                }
            }
            else
            {
                // Create new category
                category = new ParentCategory() { Name = req.Name };
                _context.ParentCategories.Add(category);
            }
            await _context.SaveChangesAsync();
            return new ChildCategoryRes { Id = category.Id, Name = category.Name };
        }
        private async Task<ChildCategoryRes> SaveChildCategory(SaveRequestDTO req)
        {
            ChildCategory? category;
            if (req.Id > 0)
            {
                // Check for duplicate category name
                var categories = await _context.ChildCategories.Where(c => c.Name == req.Name || c.Id == req.Id).ToListAsync();
                var dupCategory = categories.Where(c => c.Id != req.Id && c.Name == req.Name).FirstOrDefault();
                if (dupCategory != null)
                {
                    throw new Exception("Category with this name already exists");
                }
                else
                {
                    category = categories.Where(c => c.Id == req.Id).FirstOrDefault();
                    if (category != null)
                    {
                        category.Name = req.Name;
                        category.ParentCategoryId = req.ParentId.Value;
                        _context.ChildCategories.Update(category);
                    }
                    else
                    {
                        throw new Exception("Provided category id does not exists");
                    }
                }
            }
            else
            {
                // Create new category
                category = new ChildCategory() { Name = req.Name, ParentCategoryId = req.ParentId.Value };
                _context.ChildCategories.Add(category);
            }
            await _context.SaveChangesAsync();
            return new ChildCategoryRes { Id = category.Id, Name = category.Name, ParentCategoryId = req.ParentId.Value };
        }

        private async Task<ChildCategoryRes> SaveCategory<TCategory>(SaveRequestDTO req, DbSet<TCategory> dbSet)
    where TCategory : class, ICategory, new()
        {
            TCategory? category;
            // Ensure that the _context is properly scoped and available for use
            if (_context.Database.GetDbConnection().State == System.Data.ConnectionState.Closed)
            {
                await _context.Database.OpenConnectionAsync(); // Open the connection explicitly if needed
            }
            if (req.Id > 0)
            {
                // Check for duplicate category name
                var categories = await dbSet.Where(c => c.Name == req.Name || c.Id == req.Id).ToListAsync();
                var dupCategory = categories.Where(c => c.Id != req.Id && c.Name == req.Name).FirstOrDefault();
                if (dupCategory != null)
                {
                    throw new Exception("Category with this name already exists");
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
                        throw new Exception("Provided category id does not exists");
                    }
                }
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

            await _context.SaveChangesAsync();
            return new ChildCategoryRes { Id = category.Id, Name = category.Name, ParentCategoryId = (req.ParentId == null) ? 0 : req.ParentId.Value };
        }
    }
}
