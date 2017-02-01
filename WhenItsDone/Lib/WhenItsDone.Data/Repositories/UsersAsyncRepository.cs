using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
