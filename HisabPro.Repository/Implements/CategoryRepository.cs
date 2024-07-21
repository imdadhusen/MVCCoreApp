using AutoMapper;
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
    }
}
