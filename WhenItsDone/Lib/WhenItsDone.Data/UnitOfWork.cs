using System;
using System.Threading.Tasks;
using WhenItsDone.Data.Contracts;

namespace WhenItsDone.Data
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
        
        public async Task<int> SaveChanges()
        {
            return await this.dbContext.SaveChangesAsync();
        }
    }
}
