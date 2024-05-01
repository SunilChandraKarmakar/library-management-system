using LibraryManagementSystem.DbMigration.DatabaseContext;
using LibraryManagementSystem.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly LibraryManagementSystemDbContext _dbContext;

        public BaseRepository()
        {
            _dbContext = new LibraryManagementSystemDbContext();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int? id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<bool> Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}