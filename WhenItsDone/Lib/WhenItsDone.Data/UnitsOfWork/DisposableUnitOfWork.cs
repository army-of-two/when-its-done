using System;
using System.Threading.Tasks;

using WhenItsDone.Data.Contracts;

namespace WhenItsDone.Data.UnitsOfWork
{
    public class DisposableUnitOfWork : IDisposableUnitOfWork, IUnitOfWork, IDisposable
    {
        private readonly IWhenItsDoneDbContext dbContext;

        public DisposableUnitOfWork(IWhenItsDoneDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext");
            }

            this.dbContext = dbContext;
        }

        public Task<int> SaveChangesAsync()
        {
            return this.dbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
