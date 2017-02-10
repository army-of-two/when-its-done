using System.Linq;

using AutoMapper;

using WhenItsDone.Data.Contracts;
using WhenItsDone.DTOs.UserViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Repositories
{
    public class UsersAsyncRepository : GenericAsyncRepository<User>, IUsersAsyncRepository, IAsyncRepository<User>
    {
        public UsersAsyncRepository(IWhenItsDoneDbContext dbContext)
            : base(dbContext)
        {
        }

        public UsernameProfilePictureUserViewDTO GetCurrentUserProfilePicture(string username)
        {
            return this.DbSet.Where(user => user.Username == username).ProjectToFirstOrDefault<UsernameProfilePictureUserViewDTO>();
        }
    }
}
