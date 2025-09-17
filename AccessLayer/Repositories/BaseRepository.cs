using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data_Access;

namespace Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly TbotDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(TbotDbContext dbContext) 
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
           _dbSet.Remove(entity);
            
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<PaginatedResult<T>> GetPaginate(int page, int pageSize)
        {
            if (page < 1) page = 1;

            if (pageSize < 1) pageSize = 10;

            var items = await _dbSet.Skip((page - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

            return new PaginatedResult<T>(items, page,pageSize);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }


    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public PaginatedResult(IEnumerable<T> items, int currentPage, int pageSize)
        {
            Items = items;
            PageSize = pageSize;
            CurrentPage = currentPage;
        }
    }

}
