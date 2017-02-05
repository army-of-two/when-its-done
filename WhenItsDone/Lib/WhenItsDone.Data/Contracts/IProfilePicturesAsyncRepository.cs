using System.Threading.Tasks;

using WhenItsDone.Models;

namespace WhenItsDone.Data.Contracts
{
    public interface IProfilePicturesAsyncRepository : IAsyncRepository<ProfilePicture>
    {
        Task<ProfilePicture> GetDefaultProfilePicture();
    }
}
