using AutoMapper;
using HisabPro.DTO.Request;
using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            ChildCategoryRes? category;
            if (req.ParentId.HasValue && req.ParentId.Value > 1)
            {
                //Save in child category
                category = await Save(req, _context.ChildCategories);
            }
            else
            {
                //Save in parent category
                category = await Save(req, _context.ParentCategories);
            }
            return category;
        }

        private async Task<ChildCategoryRes> Save<TCategory>(SaveRequestDTO req, DbSet<TCategory> dbSet)
    where TCategory : class, ICategory, new()
        {
            TCategory? category;
            if (req.Id > 0)
            {
                // Check for duplicate category name
                var categories = await dbSet.Where(c => c.Name.Trim() == req.Name.Trim() || c.Id == req.Id).ToListAsync();
                var dupCategory = categories.Where(c => c.Id != req.Id && c.Name.Trim() == req.Name.Trim()).FirstOrDefault();
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
                // Check for duplicate category name
                var dupCategory = await dbSet.Where(c => c.Name.Trim() == req.Name.Trim()).FirstOrDefaultAsync();
                if (dupCategory != null)
                {
                    throw new Exception("Category with this name already exists");
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
            return new ChildCategoryRes { Id = category.Id, Name = category.Name, ParentCategoryId = (req.ParentId == null) ? 0 : req.ParentId.Value };
        }
    }
}
