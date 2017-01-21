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

        private readonly Func<AsyncGenericRepository<TEntity>, int, TEntity> getByIdDelegate = (AsyncGenericRepository<TEntity> context, int id) =>
        {
            var result = context.dbSet.Find(id);

            return result;
        };

        private readonly Func<AsyncGenericRepository<TEntity>, IEnumerable<TEntity>> getAllDelegate = (AsyncGenericRepository<TEntity> context) =>
        {
            var result = context.dbSet.ToList().AsEnumerable();

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

        public Task<TEntity> GetByIdAsync(int id)
        {
            var getByIdTask = Task.Run(() => this.getByIdDelegate(this, id));

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

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var getAllTask = Task.Run(() => this.getAllDelegate(this));

            return getAllTask;
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

        public Task<IEnumerable<TResult>> GetAll<T, TResult>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, T>> orderBy,
            Expression<Func<TEntity, TResult>> select,
            int page,
            int pageSize)
        {
            IQueryable<TEntity> resultingQuery = this.dbSet;

            resultingQuery = resultingQuery.OrderBy(x => x.Id);

            if (filter != null)
            {
                resultingQuery = resultingQuery.Where(filter);
            }

            if (orderBy != null)
            {
                resultingQuery = resultingQuery.OrderBy(orderBy);
            }

            if (select != null)
            {
                resultingQuery.Select(select);
            }

            resultingQuery = resultingQuery
                        .Where(x => !x.IsDeleted)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            var runningTask = Task.Run(() =>
            {
                var result = resultingQuery.OfType<TResult>().ToList().AsEnumerable();

                return result;
            });

            return runningTask;
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
