using Microsoft.EntityFrameworkCore;
using Project.VHM20.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Persistence.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public DbSet<T> BaseEntity => _context.Set<T>();

        public Task<IQueryable<T>> FindAllAsync() => Task.FromResult<IQueryable<T>>(BaseEntity);

        public Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> predicate) => Task.FromResult(BaseEntity.Where(predicate));

        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => BaseEntity.FirstOrDefaultAsync(predicate);

        public Task<int> CountAsync() => BaseEntity.CountAsync();

        public Task<int> CountAsync(Expression<Func<T, bool>> predicate) => BaseEntity.CountAsync(predicate);

        public ValueTask<T?> FindByIdAsync(int id) => BaseEntity.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await BaseEntity.AddAsync(entity).ConfigureAwait(true);
        }

        public Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            BaseEntity.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Add(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Remove(entity);
            return Task.CompletedTask;
        }
    }
}
