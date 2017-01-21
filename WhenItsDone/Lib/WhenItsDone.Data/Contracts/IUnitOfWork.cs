using System.Threading.Tasks;

namespace WhenItsDone.Data.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}
