using Bytes2you.Validation;

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
            Guard.WhenArgument(userDbModelFactory, nameof(IInitializedUserFactory)).IsNull();
            Guard.WhenArgument(usersAsyncRepository, nameof(IUsersAsyncRepository)).IsNull();
            Guard.WhenArgument(profilePicturesAsyncRepository, nameof(IProfilePicturesAsyncRepository)).IsNull();

            this.userDbModelFactory = userDbModelFactory;
            this.usersAsyncRepository = usersAsyncRepository;
            this.profilePicturesAsyncRepository = profilePicturesAsyncRepository;
        }

        public bool CreateUser(string username)
        {
            var isSuccessful = false;

            if (string.IsNullOrEmpty(username))
            {
                return isSuccessful;
            }

            var nextUser = this.userDbModelFactory.GetInitializedUser(username);
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
