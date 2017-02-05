using System.Linq;
using System.Threading.Tasks;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Repositories
{
    public class ProfilePicturesAsyncRepository : GenericAsyncRepository<ProfilePicture>, IProfilePicturesAsyncRepository, IAsyncRepository<ProfilePicture>
    {
        public ProfilePicturesAsyncRepository(IWhenItsDoneDbContext dbContext)
            : base(dbContext)
        {
        }

        public Task<ProfilePicture> GetDefaultProfilePicture()
        {
            var task = Task.Run(() => base.DbSet.FirstOrDefault());
            return task;
        }
    }
}
