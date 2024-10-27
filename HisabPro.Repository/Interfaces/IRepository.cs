namespace HisabPro.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithChildrenAsync(params string[] children);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByNameAsync(string name);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> ExistsAsync(string name, int? id = null); // Optional id for edit
    }
}
