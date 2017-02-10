using System;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.DTOs.UserViewsDTOs;
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
            if (asyncRepository == null)
            {
                throw new ArgumentNullException(nameof(IUsersAsyncRepository));
            }

            this.asyncRepository = asyncRepository;
        }

        public UsernameProfilePictureUserViewDTO GetCurrentUserProfilePicture(string username)
        {

            return null;
        }
    }
}
