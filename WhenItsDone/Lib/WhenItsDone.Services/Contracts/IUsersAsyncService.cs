using WhenItsDone.DTOs.UserViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IUsersAsyncService : IGenericAsyncService<User>
    {
        UsernameProfilePictureUserViewDTO GetCurrentUserProfilePicture(string username);

        User UpdateUserProfilePicture(string username, string uploadedFileName, byte[] uploadedFile);

        User UpdateUserProfilePicture(string username, string profilePictureUrl);
    }
}
