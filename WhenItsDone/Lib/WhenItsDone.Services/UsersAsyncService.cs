using Bytes2you.Validation;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models;
using WhenItsDone.Models.Factories;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services
{
    public class UsersAsyncService : GenericAsyncService<User>, IUsersAsyncService, IGenericAsyncService<User>
    {
        private readonly IUsersAsyncRepository asyncRepository;
        private readonly IInitializedUserFactory userDbModelFactory;

        public UsersAsyncService(IUsersAsyncRepository asyncRepository, IDisposableUnitOfWorkFactory unitOfWorkFactory, IInitializedUserFactory userDbModelFactory)
            : base(asyncRepository, unitOfWorkFactory)
        {
            Guard.WhenArgument(userDbModelFactory, nameof(IInitializedUserFactory)).IsNull();
            Guard.WhenArgument(asyncRepository, nameof(IUsersAsyncRepository)).IsNull();

            this.userDbModelFactory = userDbModelFactory;
            this.asyncRepository = asyncRepository;
        }

        public bool CreateUser(string username)
        {
            var isSuccessful = false;

            if (string.IsNullOrEmpty(username))
            {
                return isSuccessful;
            }

            var nextUser = this.userDbModelFactory.GetInitializedUser(username);

            this.asyncRepository.Add(nextUser);
            using (var unitOfWork = base.UnitOfWorkFactory.CreateUnitOfWork())
            {
                var result = unitOfWork.SaveChanges();
                if (result != 0)
                {
                    isSuccessful = true;
                }
            }

            return isSuccessful;
        }
    }
}
