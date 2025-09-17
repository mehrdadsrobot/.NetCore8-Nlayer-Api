using Microsoft.AspNetCore.Mvc;
using Models.UserModels;

namespace Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
        Task<PaginatedResult<T>> GetPaginate(int page , int pageSize);
    }
}
