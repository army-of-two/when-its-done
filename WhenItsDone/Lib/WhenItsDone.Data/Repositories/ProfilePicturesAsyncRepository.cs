using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public ProfilePicture GetDefaultProfilePicture()
        {
            throw new NotImplementedException();
        }
    }
}
