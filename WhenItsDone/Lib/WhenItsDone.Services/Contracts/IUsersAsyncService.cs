using WhenItsDone.DTOs.UserViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IUsersAsyncService : IGenericAsyncService<User>
    {
        ContactInformationUserViewDTO GetCurrentUserContactInformation(string username);

        MedicalInformationUserViewDTO GetCurrentUserMedicalInformation(string username);

        UsernameProfilePictureUserViewDTO GetCurrentUserProfilePicture(string username);

        User UpdateUserProfilePicture(string username, string uploadedFileName, byte[] uploadedFile);

        User UpdateUserProfilePictureFromUrl(string username, string profilePictureUrl);

        User UpdateUserMedicalInformationFromUserInput(string username, string heightInCm, string weightInKg);
    }
}
