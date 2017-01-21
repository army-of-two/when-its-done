using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WhenItsDone.Services.Contracts
{
    public interface IFactoryGenericAsyncService<T>
    {
        Task<T> GetById(int id);

        Task<T> Add(T item);

        Task<T> Update(T item);

        Task<int> Hide(T item);

        Task<int> Delete(T item);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter);

        Task<IEnumerable<T>> GetAll<T1>(
           Expression<Func<T, bool>> filter,
           Expression<Func<T, T1>> orderBy);

        Task<IEnumerable<TResult>> GetAll<T1, TResult>(
           Expression<Func<T, bool>> filter,
           Expression<Func<T, T1>> orderBy,
           Expression<Func<T, TResult>> select);

        Task<IEnumerable<T>> GetAll(
           Expression<Func<T, bool>> filter,
           int page,
           int pageSize);

        Task<IEnumerable<T>> GetAll<T1>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, T1>> orderBy,
            int page,
            int pageSize);

        Task<IEnumerable<TResult>> GetAll<T1, TResult>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, T1>> orderBy,
            Expression<Func<T, TResult>> select,
            int page,
            int pageSize);

        Task<IEnumerable<T>> GetDeleted();
    }
}

