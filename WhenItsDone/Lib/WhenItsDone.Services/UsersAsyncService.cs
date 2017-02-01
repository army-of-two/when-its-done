using System;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;
using WhenItsDone.Services.Factories;

namespace WhenItsDone.Services
{
    public class UsersAsyncService : GenericAsyncService<User>, IUsersAsyncService, IGenericAsyncService<User>
    {
        private readonly IUsersAsyncRepository asyncRepository;
        private readonly IUserFactory userFactory;

        public UsersAsyncService(IUsersAsyncRepository asyncRepository, IDisposableUnitOfWorkFactory unitOfWorkFactory, IUserFactory userFactory)
            : base(asyncRepository, unitOfWorkFactory)
        {
            if (userFactory == null)
            {
                throw new ArgumentNullException(nameof(userFactory));
            }

            this.userFactory = userFactory;

            this.asyncRepository = asyncRepository;
        }

        public User CreateUser(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            var nextUser = this.userFactory.CreateUser();

            return nextUser;
        }
    }
}
