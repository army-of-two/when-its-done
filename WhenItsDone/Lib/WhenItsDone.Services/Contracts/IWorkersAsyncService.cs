using System.Collections.Generic;
using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IWorkersAsyncService : IGenericAsyncService<Worker>
    {
        IEnumerable<Worker> GetWorkersWithDIshes();
    }
}
