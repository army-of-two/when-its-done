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

        public bool CreateUser(string username)
        {
            var isSuccessful = false;

            if (string.IsNullOrEmpty(username))
            {
                return isSuccessful;
            }

            var nextUser = this.userFactory.CreateUser();
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
