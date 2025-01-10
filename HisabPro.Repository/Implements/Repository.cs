using HisabPro.Entities.Models;
using HisabPro.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // This method will return only selected columns based on the selector function
        public async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selector)
        {
            return await _dbSet.Select(selector).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithChildrenAsync(params string[] children)
        {
            IQueryable<T> query = _dbSet;
            foreach (var child in children)
            {
                query = query.Include(child);
            }
            return await query.ToListAsync();
        }

        public IQueryable<T> GetPageDataWithChildrenAsync(params string[] children)
        {
            IQueryable<T> query = _dbSet;
            foreach (var child in children)
            {
                query = query.Include(child);
            }
            return query.AsQueryable();
        }
        public IQueryable<T> GetAllDataWithSelfRefAsync(Expression<Func<T, bool>> filter, params string[] children)
        {
            IQueryable<T> query = _dbSet;
            foreach (var child in children)
            {
                query = query.Include(child).Where(filter);
            }
            return query.AsQueryable();
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

        public async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            var affectedRows = await _context.SaveChangesWithAuditAsync();
            return affectedRows;
        }

        public async Task<T> AddAsync(T entity, bool useFallback = false)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesWithAuditAsync(useFallback);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesWithAuditAsync();
            return entity;
        }

        public async Task<T> SaveAsync(T entity, bool useFallback = false)
        {
            var primaryKey = _context.Model.FindEntityType(typeof(T))?.FindPrimaryKey();
            if (primaryKey == null)
            {
                throw new InvalidOperationException("Entity does not have a primary key defined.");
            }

            // Assume the first key property as the primary key
            var keyProperty = primaryKey.Properties.First();
            var keyValue = keyProperty.PropertyInfo.GetValue(entity);

            if (keyValue == null || keyValue.Equals(default(int))) // Assuming int as primary key type
            {
                // Key is not set, so treat it as a new entity
                await _dbSet.AddAsync(entity);
            }
            else
            {
                // Key is set, so treat it as an existing entity
                _dbSet.Update(entity);
            }

            await _context.SaveChangesWithAuditAsync(useFallback: useFallback);
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

        // Delete by entity ID
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return false; // Entity not found
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesWithAuditAsync();
            return true;
        }

        // Delete by entity instance
        public async Task<bool> DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity); // Attach entity if not tracked
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesWithAuditAsync();
            return true;
        }
    }
}
