using WhenItsDone.DTOs.UserViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Contracts
{
    public interface IUsersAsyncRepository : IAsyncRepository<User>
    {
        User GetCurrentUserIncludingMedicalInformation(string username);

        ContactInformationUserViewDTO GetCurrentUserContactInformation(string username);

        MedicalInformationUserViewDTO GetCurrentUserMedicalInformation(string username);

        UsernameProfilePictureUserViewDTO GetCurrentUserProfilePicture(string username);
    }
}
