using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models;
using WhenItsDone.Services.Abstraction;

namespace WhenItsDone.Services
{
    public class WorkersDataService : FactoryGenericAsyncService<Worker>
    {
        public WorkersDataService(IAsyncRepository<Worker> repository, IDisposableUnitOfWorkFactory unitOfWorkFactory)
            : base(repository, unitOfWorkFactory)
        {
        }
    }
}
