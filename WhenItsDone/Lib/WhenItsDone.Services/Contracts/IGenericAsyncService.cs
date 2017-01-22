using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WhenItsDone.Services.Contracts
{
    public interface IGenericAsyncService<T>
    {
        Task<T> GetById(int id);

        T Add(T item);

        T Update(T item);

        void Hide(T item);

        void Delete(T item);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetAll<T1>(
           Expression<Func<T, bool>> filter,
           Expression<Func<T, T1>> orderBy);

        IEnumerable<TResult> GetAll<T1, TResult>(
           Expression<Func<T, bool>> filter,
           Expression<Func<T, T1>> orderBy,
           Expression<Func<T, TResult>> select);

        IEnumerable<T> GetAll(
           Expression<Func<T, bool>> filter,
           int page,
           int pageSize);

        IEnumerable<T> GetAll<T1>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, T1>> orderBy,
            int page,
            int pageSize);

        IEnumerable<TResult> GetAll<T1, TResult>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, T1>> orderBy,
            Expression<Func<T, TResult>> select,
            int page,
            int pageSize);

        IEnumerable<T> GetDeleted();
    }
}

