using WhenItsDone.Data.Contracts;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Repositories
{
    public class UsersAsyncRepository : GenericAsyncRepository<User>, IUsersAsyncRepository, IAsyncRepository<User>
    {
        public UsersAsyncRepository(IWhenItsDoneDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
