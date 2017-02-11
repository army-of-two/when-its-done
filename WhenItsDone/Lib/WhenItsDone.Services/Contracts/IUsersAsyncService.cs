using WhenItsDone.DTOs.UserViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IUsersAsyncService : IGenericAsyncService<User>
    {
        MedicalInformationUserViewDTO GetCurrentUserMedicalInformation(string username);

        UsernameProfilePictureUserViewDTO GetCurrentUserProfilePicture(string username);

        User UpdateUserProfilePicture(string username, string uploadedFileName, byte[] uploadedFile);

        User UpdateUserProfilePictureFromUrl(string username, string profilePictureUrl);
    }
}
