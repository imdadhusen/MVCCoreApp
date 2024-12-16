using System.Linq.Expressions;

namespace HisabPro.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync();
        Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selector);
        Task<IEnumerable<T>> GetAllWithChildrenAsync(params string[] children);
        IQueryable<T> GetPageDataWithChildrenAsync(params string[] children);

        IQueryable<T> GetAllDataWithSelfRefAsync(Expression<Func<T, bool>> filter, params string[] children);

        Task<T> GetByIdAsync(int id);
        Task<T> GetByNameAsync(string name);
        Task<bool> ExistsAsync(string name, int? id = null); // Optional id for edit

        Task<int> AddRangeAsync(IEnumerable<T> entities);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> SaveAsync(T entity);


        Task<bool> DeleteAsync(int id); // Delete by ID
        Task<bool> DeleteAsync(T entity); // Delete by entity instance
    }
}
