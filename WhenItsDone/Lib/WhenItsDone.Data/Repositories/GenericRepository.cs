using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Data.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDbModel
    {
        private readonly IWhenItsDoneDbContext dbContext;
        private readonly IDbSet<TEntity> dbSet;

        public GenericRepository(IWhenItsDoneDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext");
            }

            this.dbContext = dbContext;

            if (dbContext.Set<TEntity>() == null)
            {
                throw new ArgumentNullException("DbSet");
            }

            this.dbSet = dbContext.Set<TEntity>();
        }

        public TEntity GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return this.GetAll<TEntity, TEntity>(filter, null, null);
        }

        public IEnumerable<TEntity> GetAll<T>(Expression<Func<TEntity, bool>> filter,
                                                    Expression<Func<TEntity, T>> orderBy)
        {
            return this.GetAll<T, TEntity>(filter, orderBy, null);
        }

        public IEnumerable<TResult> GetAll<T, TResult>(Expression<Func<TEntity, bool>> filter,
                                            Expression<Func<TEntity, T>> orderBy,
                                            Expression<Func<TEntity, TResult>> select)
        {
            return this.GetAll(filter, orderBy, select, 0, int.MaxValue);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter,
                                        int page,
                                        int pageSize)
        {
            return this.GetAll<TEntity, TEntity>(filter, null, null, page, pageSize);
        }

        public IEnumerable<TEntity> GetAll<T>(Expression<Func<TEntity, bool>> filter,
                                        Expression<Func<TEntity, T>> orderBy,
                                        int page,
                                        int pageSize)
        {
            return this.GetAll<T, TEntity>(filter, orderBy, null, page, pageSize);
        }

        public IEnumerable<TResult> GetAll<T, TResult>(Expression<Func<TEntity, bool>> filter,
                                            Expression<Func<TEntity, T>> orderBy,
                                            Expression<Func<TEntity, TResult>> select,
                                            int page,
                                            int pageSize)
        {
            IQueryable<TEntity> result = this.dbSet;

            result = result.OrderBy(x => x.Id);

            if (filter != null)
            {
                result = result.Where(filter);
            }

            if (orderBy != null)
            {
                result = result.OrderBy(orderBy);
            }

            if (select != null)
            {
                result.Select(select);
            }

            result = result
                        .Where(x => !x.IsDeleted)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return result.OfType<TResult>().ToList();
        }

        public IEnumerable<TEntity> GetDeleted()
        {
            return this.dbSet
                        .Where(x => x.IsDeleted);
        }

        public void Update(TEntity entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        private DbEntityEntry AttachIfDetached(TEntity entity)
        {
            var entry = this.dbContext.Entry(entity);

            if (entry.State == EntityState.Deleted)
            {
                this.dbSet.Attach(entity);
            }

            return entry;
        }
    }
}
