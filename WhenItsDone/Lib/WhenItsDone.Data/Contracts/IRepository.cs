using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WhenItsDone.Data.Contracts
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(object id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> GetAll<T>(Expression<Func<TEntity, bool>> filter,
                                        Expression<Func<TEntity, T>> orderBy);

        IEnumerable<TResult> GetAll<T, TResult>(Expression<Func<TEntity, bool>> filter,
                                                    Expression<Func<TEntity, T>> orderBy,
                                                    Expression<Func<TEntity, TResult>> select);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter,
                                        int page,
                                        int pageSize);

        IEnumerable<TEntity> GetAll<T>(Expression<Func<TEntity, bool>> filter,
                                        Expression<Func<TEntity, T>> orderBy,
                                        int page,
                                        int pageSize);

        IEnumerable<TResult> GetAll<T, TResult>(Expression<Func<TEntity, bool>> filter,
                                                    Expression<Func<TEntity, T>> orderBy,
                                                    Expression<Func<TEntity, TResult>> select,
                                                    int page,
                                                    int pageSize);

        IEnumerable<TEntity> GetDeleted();
    }
}
