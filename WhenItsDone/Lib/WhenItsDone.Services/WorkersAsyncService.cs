using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services
{
    public class WorkersAsyncService : GenericAsyncService<Worker>, IWorkersAsyncService, Contracts.IGenericAsyncService<Worker>
    {
        public WorkersAsyncService(IAsyncRepository<Worker> repository, IDisposableUnitOfWorkFactory unitOfWorkFactory)
            : base(repository, unitOfWorkFactory)
        {
        }
    }
}
