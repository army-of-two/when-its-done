using WhenItsDone.Models;

namespace WhenItsDone.Data.Contracts
{
    public interface IProfilePicturesAsyncRepository : IAsyncRepository<ProfilePicture>
    {
        ProfilePicture GetDefaultProfilePicture();
    }
}
