using System;
using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IUsersRegistrationAsyncService : IGenericAsyncService<User>
    {
        bool CreateUser(Guid aspUserId, string username);
    }
}
