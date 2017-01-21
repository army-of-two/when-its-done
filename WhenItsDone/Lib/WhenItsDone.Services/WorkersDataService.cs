using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services
{
    public class WorkersDataService : GenericAsyncService<Worker>, IGenericAsyncService<Worker>
    {
        public WorkersDataService(IAsyncRepository<Worker> repository, IDisposableUnitOfWorkFactory unitOfWorkFactory)
            : base(repository, unitOfWorkFactory)
        {
        }
    }
}
