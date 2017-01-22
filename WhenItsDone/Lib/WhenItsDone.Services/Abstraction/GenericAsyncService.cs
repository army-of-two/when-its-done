using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models.Contracts;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services.Abstraction
{
    public class GenericAsyncService<T> : IGenericAsyncService<T>
            where T : class, IDbModel
    {
        private readonly IAsyncRepository<T> asyncRepository;
        private readonly IDisposableUnitOfWorkFactory unitOfWorkFactory;

        public GenericAsyncService(IAsyncRepository<T> asyncRepository, IDisposableUnitOfWorkFactory unitOfWorkFactory)
        {
            if (asyncRepository == null)
            {
                throw new ArgumentNullException(nameof(asyncRepository));
            }

            if (unitOfWorkFactory == null)
            {
                throw new ArgumentNullException(nameof(unitOfWorkFactory));
            }

            this.asyncRepository = asyncRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await this.asyncRepository.GetByIdAsync(id);
        }

        public virtual T Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Invalid item to add!");
            }

            this.asyncRepository.Add(item);
            using (var unitOfWork = this.unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.SaveChangesAsync();
            }

            return item;
        }

        public virtual T Update(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Invalid item to update!");
            }

            this.asyncRepository.Update(item);
            using (var unitOfWork = this.unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.SaveChangesAsync();
            }

            return item;
        }

        public virtual void Hide(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Invalid item to hide!");
            }

            item.IsDeleted = true;
            this.asyncRepository.Update(item);
            using (var unitOfWork = this.unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.SaveChangesAsync();
            }
        }

        public virtual void Delete(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Invalid item to delete!");
            }

            this.asyncRepository.Delete(item);
            using (var unitOfWork = this.unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.SaveChangesAsync();
            }
        }

        public virtual IEnumerable<T> GetDeleted()
        {
            return this.GetAll((x) => x.IsDeleted);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.asyncRepository.GetAllAsync().Result;
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            return this.asyncRepository.GetAll(filter).Result;
        }

        public virtual IEnumerable<T> GetAll<T1>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, T1>> orderBy)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            if (orderBy == null)
            {
                throw new ArgumentNullException(nameof(orderBy));
            }

            return this.asyncRepository.GetAll(filter, orderBy).Result;
        }

        public virtual IEnumerable<TResult> GetAll<T1, TResult>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, T1>> orderBy,
            Expression<Func<T, TResult>> select)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            if (orderBy == null)
            {
                throw new ArgumentNullException(nameof(orderBy));
            }

            if (select == null)
            {
                throw new ArgumentNullException(nameof(select));
            }

            return this.asyncRepository.GetAll(filter, orderBy, select).Result;
        }

        public virtual async Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>> filter,
            int page,
            int pageSize)
        {
            return await this.asyncRepository.GetAll(filter, page, pageSize);
        }

        public virtual async Task<IEnumerable<T>> GetAll<T1>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, T1>> orderBy,
            int page,
            int pageSize)
        {
            return await this.asyncRepository.GetAll(filter, orderBy, page, pageSize);
        }

        public virtual async Task<IEnumerable<TResult>> GetAll<T1, TResult>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, T1>> orderBy,
            Expression<Func<T, TResult>> select,
            int page,
            int pageSize)
        {
            return await this.asyncRepository.GetAll(filter, orderBy, select, page, pageSize);
        }
    }
}
