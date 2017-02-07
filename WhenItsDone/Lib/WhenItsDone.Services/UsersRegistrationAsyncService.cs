using System;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models;
using WhenItsDone.Models.Factories;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services
{
    public class UsersRegistrationAsyncService : GenericAsyncService<User>, IUsersRegistrationAsyncService, IGenericAsyncService<User>
    {
        private readonly IUsersAsyncRepository usersAsyncRepository;
        private readonly IInitializedUserFactory userDbModelFactory;
        private readonly IProfilePicturesAsyncRepository profilePicturesAsyncRepository;

        public UsersRegistrationAsyncService(IUsersAsyncRepository usersAsyncRepository, IProfilePicturesAsyncRepository profilePicturesAsyncRepository, IDisposableUnitOfWorkFactory unitOfWorkFactory, IInitializedUserFactory userDbModelFactory)
            : base(usersAsyncRepository, unitOfWorkFactory)
        {
            if (userDbModelFactory == null)
            {
                throw new ArgumentNullException(nameof(IInitializedUserFactory));
            }

            if (usersAsyncRepository == null)
            {
                throw new ArgumentNullException(nameof(IUsersAsyncRepository));
            }

            if (profilePicturesAsyncRepository == null)
            {
                throw new ArgumentNullException(nameof(IProfilePicturesAsyncRepository));
            }

            this.userDbModelFactory = userDbModelFactory;
            this.usersAsyncRepository = usersAsyncRepository;
            this.profilePicturesAsyncRepository = profilePicturesAsyncRepository;
        }

        public bool CreateUser(Guid aspUserId, string username)
        {
            var isSuccessful = false;
            if (string.IsNullOrEmpty(username))
            {
                return isSuccessful;
            }

            var nextUser = this.userDbModelFactory.GetInitializedUser(aspUserId, username);
            nextUser.ProfilePicture = this.profilePicturesAsyncRepository.GetDefaultProfilePicture().Result;

            this.usersAsyncRepository.Add(nextUser);
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
