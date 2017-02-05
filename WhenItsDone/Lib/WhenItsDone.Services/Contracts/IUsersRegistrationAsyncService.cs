using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IUsersRegistrationAsyncService : IGenericAsyncService<User>
    {
        bool CreateUser(string username);
    }
}
