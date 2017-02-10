using WhenItsDone.DTOs.UserViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Contracts
{
    public interface IUsersAsyncRepository : IAsyncRepository<User>
    {
        UsernameProfilePictureUserViewDTO GetCurrentUserProfilePicture(string username);
    }
}
