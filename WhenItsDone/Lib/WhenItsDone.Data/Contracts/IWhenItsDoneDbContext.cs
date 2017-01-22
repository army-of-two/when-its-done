using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace WhenItsDone.Data.Contracts
{
    public interface IWhenItsDoneDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        IStateful<TEntity> GetStateful<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}
