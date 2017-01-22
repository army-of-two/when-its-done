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
    public class AsyncGenericRepository<TEntity> : IAsyncRepository<TEntity>
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

        private readonly Func<AsyncGenericRepository<TEntity>, IEnumerable<TEntity>> getDeletedDelegate = (AsyncGenericRepository<TEntity> context) =>
        {
            var result = context.dbSet.Where(x => x.IsDeleted).ToList().AsEnumerable();

            return result;
        };

        public AsyncGenericRepository(IWhenItsDoneDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext");
            }

            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();

            if (this.dbSet == null)
            {
                throw new ArgumentException("DbContext does not contain DbSet<{0}>", typeof(TEntity).Name);
            }
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id must be a positive integer.");
            }

            var getByIdTask = Task.Run(() => this.getByIdDelegate(this, id));

            return getByIdTask;
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var getAllTask = Task.Run(() => this.getAllDelegate(this));

            return getAllTask;
        }

        public Task<IEnumerable<TEntity>> GetDeleted()
        {
            var getDeletedTask = Task.Run(() => this.getDeletedDelegate(this));

            return getDeletedTask;
        }

        public Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            var queryToExecute = this.BuildQuery<int>(filter, null, 0, int.MaxValue);

            var task = this.CreateTask(queryToExecute);

            return task;
        }

        public Task<IEnumerable<TEntity>> GetAll<T>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, T>> orderBy)
        {
            return this.GetAll<T, TEntity>(filter, orderBy, null);
        }

        public Task<IEnumerable<TResult>> GetAll<T, TResult>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, T>> orderBy,
            Expression<Func<TEntity, TResult>> select)
        {
            return this.GetAll(filter, orderBy, select, 0, int.MaxValue);
        }

        public Task<IEnumerable<TEntity>> GetAll(
            Expression<Func<TEntity, bool>> filter,
            int page,
            int pageSize)
        {
            return this.GetAll<TEntity, TEntity>(filter, null, null, page, pageSize);
        }

        public Task<IEnumerable<TEntity>> GetAll<T>(
            Expression<Func<TEntity, bool>> filter,
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
            IQueryable<TEntity> queryToExecute = this.BuildQuery<T>(filter, orderBy, page, pageSize);

            var queryWithSelect = queryToExecute.Select(select);

            var runningTask = Task.Run(() =>
            {
                var result = queryWithSelect.ToList().AsEnumerable();

                return result;
            });

            return runningTask;
        }

        private IQueryable<TEntity> BuildQuery<T>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, T>> orderBy,
            int page,
            int pageSize)
        {
            IQueryable<TEntity> queryToExecute = this.dbSet;

            queryToExecute = queryToExecute.OrderBy(x => x.Id);

            if (filter != null)
            {
                queryToExecute = queryToExecute.Where(filter);
            }

            if (orderBy != null)
            {
                queryToExecute = queryToExecute.OrderBy(orderBy);
            }

            queryToExecute = queryToExecute
                .Where(x => !x.IsDeleted)
                .Skip(page * pageSize)
                .Take(pageSize);

            return queryToExecute;
        }
        
        private Task<IEnumerable<TEntity>> CreateTask(IQueryable<TEntity> queryToExecute)
        {
            return Task.Run(() =>
            {
                var result = queryToExecute.ToList().AsEnumerable();

                return result;
            });
        }
    }
}
