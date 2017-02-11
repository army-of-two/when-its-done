using WhenItsDone.DTOs.UserViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Contracts
{
    public interface IUsersAsyncRepository : IAsyncRepository<User>
    {
        MedicalInformationUserViewDTO GetCurrentUserMedicalInformation(string username);

        UsernameProfilePictureUserViewDTO GetCurrentUserProfilePicture(string username);
    }
}
