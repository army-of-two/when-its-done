﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WhenItsDone.Data.Contracts;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Services.Abstraction
{
    public abstract class GenericService<T>
            where T : class, IDbModel
    {
        private IRepository<T> repo;
        private IUnitOfWork unitOfWork;

        public GenericService(IRepository<T> repo, IUnitOfWork unitOfWork)
        {
            this.Repo = repo;
            this.UnitOfWork = unitOfWork;
        }

        protected IRepository<T> Repo
        {
            get
            {
                return this.repo;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Repository");
                }

                this.repo = value;
            }
        }

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("UnitOfWork");
                }

                this.unitOfWork = value;
            }
        }

        public virtual T GetById(int id)
        {
            return this.repo.GetById(id);
        }

        public virtual async Task<T> Add(T item)
        {
            if (item == null || !this.IsValid(item))
            {
                throw new ArgumentException("Invalid item for add!");
            }

            using (this.unitOfWork)
            {
                this.repo.Add(item);
                await this.unitOfWork.SaveChanges();
            }

            return this.GetById(item.Id);
        }

        public virtual async Task<T> Update(T item)
        {
            if (item == null || !this.IsValid(item))
            {
                throw new ArgumentException("Invalid item for update!");
            }

            using (this.unitOfWork)
            {
                this.repo.Update(item);
                await this.unitOfWork.SaveChanges();
            }

            return this.GetById(item.Id);
        }

        public virtual async Task<int> Hide(T item)
        {
            if (item == null || !this.IsValid(item))
            {
                throw new ArgumentException("Invalid item for hide!");
            }

            using (this.unitOfWork)
            {
                item.IsDeleted = true;
                this.repo.Update(item);
                return await this.unitOfWork.SaveChanges();
            }
        }

        public virtual async Task<int> Delete(T item)
        {
            if (item == null || !this.IsValid(item))
            {
                throw new ArgumentException("Invalid item for delete!");
            }

            using (this.unitOfWork)
            {
                this.repo.Delete(item);
                return await this.unitOfWork.SaveChanges();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await Task.Run(() => this.repo.GetAll());
        }

        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            return await Task.Run(() => this.repo.GetAll(filter));
        }

        public virtual async Task<IEnumerable<T>> GetAll<T1>(Expression<Func<T, bool>> filter,
                                                    Expression<Func<T, T1>> orderBy)
        {
            return await Task.Run(() => this.repo.GetAll(filter, orderBy));
        }

        public virtual async Task<IEnumerable<TResult>> GetAll<T1, TResult>(Expression<Func<T, bool>> filter,
                                            Expression<Func<T, T1>> orderBy,
                                            Expression<Func<T, TResult>> select)
        {
            return await Task.Run(() => this.repo.GetAll(filter, orderBy, select));
        }

        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter,
                                        int page,
                                        int pageSize)
        {
            return await Task.Run(() => this.repo.GetAll(filter, page, pageSize));
        }

        public virtual async Task<IEnumerable<T>> GetAll<T1>(Expression<Func<T, bool>> filter,
                                        Expression<Func<T, T1>> orderBy,
                                        int page,
                                        int pageSize)
        {
            return await Task.Run(() => this.repo.GetAll(filter, orderBy, page, pageSize));
        }

        public virtual async Task<IEnumerable<TResult>> GetAll<T1, TResult>(Expression<Func<T, bool>> filter,
                                            Expression<Func<T, T1>> orderBy,
                                            Expression<Func<T, TResult>> select,
                                            int page,
                                            int pageSize)
        {
            return await Task.Run(() => this.repo.GetAll(filter, orderBy, select, page, pageSize));
        }

        public virtual async Task<IEnumerable<T>> GetDeleted()
        {
            return await Task.Run(() => this.GetAll((x) => x.IsDeleted));
        }

        protected abstract bool IsValid(T item);
    }
}
