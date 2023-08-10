using Project.VHM20.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Persistence.Repository.Base
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        Task<IQueryable<T>> FindAllAsync();

        Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> predicate);

        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        ValueTask<T?> FindByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;

        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;

        Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;

        Task<int> CommitAsync();
    }
}
