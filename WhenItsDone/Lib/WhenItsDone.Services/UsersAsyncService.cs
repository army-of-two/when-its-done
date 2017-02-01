using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services
{
    public class UsersAsyncService : GenericAsyncService<User>, IUsersAsyncService, IGenericAsyncService<User>
    {
        private readonly IUsersAsyncRepository asyncRepository;

        public UsersAsyncService(IUsersAsyncRepository asyncRepository, IDisposableUnitOfWorkFactory unitOfWorkFactory)
            : base(asyncRepository, unitOfWorkFactory)
        {
            this.asyncRepository = asyncRepository;
        }
    }
}
