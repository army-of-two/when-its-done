using System;
using System.Threading.Tasks;

using WhenItsDone.Data.Contracts;

namespace WhenItsDone.Data.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IWhenItsDoneDbContext dbContext;

        public UnitOfWork(IWhenItsDoneDbContext dbContext)
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
    }
}
