using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Data.Repositories
{
    public class AsyncGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDbModel
    {
        private readonly IWhenItsDoneDbContext dbContext;
        private readonly IDbSet<TEntity> dbSet;

        private readonly Func<int, AsyncGenericRepository<TEntity>, TEntity> getByIdDelegate = (int id, AsyncGenericRepository<TEntity> context) =>
        {
            var result = context.dbSet.Find(id);

            return result;
        };

        public AsyncGenericRepository(IWhenItsDoneDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext");
            }

            this.dbContext = dbContext;

            if (dbContext.Set<TEntity>() == null)
            {
                throw new ArgumentNullException("DbContext does not contain DbSet<{0}>", typeof(TEntity).Name);
            }

            this.dbSet = dbContext.Set<TEntity>();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                var result = this.dbSet.ToList();
                return (IEnumerable<TEntity>)result;
            });
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            var getByIdTask = Task.Run(() => this.getByIdDelegate(id, this));
            return getByIdTask;
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
