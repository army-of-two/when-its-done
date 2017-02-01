using System;

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
        private readonly IUserDbModelFactory userDbModelFactory;

        public UsersAsyncService(IUsersAsyncRepository asyncRepository, IDisposableUnitOfWorkFactory unitOfWorkFactory, IUserDbModelFactory userDbModelFactory)
            : base(asyncRepository, unitOfWorkFactory)
        {
            if (userDbModelFactory == null)
            {
                throw new ArgumentNullException(nameof(userDbModelFactory));
            }

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

            var nextUser = this.userDbModelFactory.CreateUser();
            nextUser.Client = this.userDbModelFactory.CreateClient();
            nextUser.Worker = this.userDbModelFactory.CreateWorker();
            nextUser.Username = username;

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
