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
    public abstract class GenericAsyncService<T> : IGenericAsyncService<T>
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
                throw new ArgumentException("Invalid item for add!");
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
                throw new ArgumentException("Invalid item for update!");
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
                throw new ArgumentException("Invalid item for hide!");
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
                throw new ArgumentException("Invalid item for delete!");
            }

            this.asyncRepository.Delete(item);
            using (var unitOfWork = this.unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.SaveChangesAsync();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await this.asyncRepository.GetAllAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            return await this.asyncRepository.GetAll(filter);
        }

        public virtual async Task<IEnumerable<T>> GetAll<T1>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, T1>> orderBy)
        {
            return await this.asyncRepository.GetAll(filter, orderBy);
        }

        public virtual async Task<IEnumerable<TResult>> GetAll<T1, TResult>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, T1>> orderBy,
            Expression<Func<T, TResult>> select)
        {
            return await this.asyncRepository.GetAll(filter, orderBy, select);
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

        public virtual async Task<IEnumerable<T>> GetDeleted()
        {
            return await this.GetAll((x) => x.IsDeleted);
        }
    }
}
