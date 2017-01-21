using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WhenItsDone.Data.Contracts
{
    public interface IAsyncRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter);

        Task<IEnumerable<TEntity>> GetAll<T>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, T>> orderBy);

        Task<IEnumerable<TResult>> GetAll<T, TResult>(
           Expression<Func<TEntity, bool>> filter,
           Expression<Func<TEntity, T>> orderBy,
           Expression<Func<TEntity, TResult>> select);

        Task<IEnumerable<TEntity>> GetAll(
           Expression<Func<TEntity, bool>> filter,
           int page,
           int pageSize);

        Task<IEnumerable<TEntity>> GetAll<T>(
           Expression<Func<TEntity, bool>> filter,
           Expression<Func<TEntity, T>> orderBy,
           int page,
           int pageSize);

        Task<IEnumerable<TResult>> GetAll<T, TResult>(
           Expression<Func<TEntity, bool>> filter,
           Expression<Func<TEntity, T>> orderBy,
           Expression<Func<TEntity, TResult>> select,
           int page,
           int pageSize);

        Task<IEnumerable<TEntity>> GetDeleted();

        void Update(TEntity entity);
    }
}
