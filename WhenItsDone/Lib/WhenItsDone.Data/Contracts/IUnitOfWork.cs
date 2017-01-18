using System;
using System.Threading.Tasks;

namespace WhenItsDone.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChanges();
    }
}
