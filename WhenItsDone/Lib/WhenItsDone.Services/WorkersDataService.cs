using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services
{
    public class WorkersDataService : FactoryGenericAsyncService<Worker>, IFactoryGenericAsyncService<Worker>
    {
        public WorkersDataService(IAsyncRepository<Worker> repository, IDisposableUnitOfWorkFactory unitOfWorkFactory)
            : base(repository, unitOfWorkFactory)
        {
        }
    }
}
