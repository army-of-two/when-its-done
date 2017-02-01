using System;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Factories;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Repositories
{
    public class UsersAsyncRepository : GenericAsyncRepository<User>, IUsersAsyncRepository, IAsyncRepository<User>
    {
        private readonly IUserFactory userFactory;

        public UsersAsyncRepository(IWhenItsDoneDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
