using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HisabPro.Repository.Implements
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllWithChildrenAsync(params string[] children)
        {
            IQueryable<T> query = _dbSet;

            // Dynamically include the specified children (navigation properties)
            foreach (var child in children)
            {
                query = query.Include(child);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByNameAsync(string name)
        {
            // Assuming Name is a property common in your models
            return await _dbSet.FirstOrDefaultAsync(e => EF.Property<string>(e, "Name") == name);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ExistsAsync(string name, int? id = null)
        {
            // Check if an entity with the same name already exists, but exclude the current entity during update
            if (id.HasValue)
            {
                return await _dbSet.AnyAsync(e => EF.Property<string>(e, "Name") == name && EF.Property<int>(e, "Id") != id.Value);
            }
            return await _dbSet.AnyAsync(e => EF.Property<string>(e, "Name") == name);
        }
    }
}
