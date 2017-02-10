using WhenItsDone.DTOs.UserViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IUsersAsyncService : IGenericAsyncService<User>
    {
        UsernameProfilePictureUserViewDTO GetCurrentUserProfilePicture(string username);
    }
}
