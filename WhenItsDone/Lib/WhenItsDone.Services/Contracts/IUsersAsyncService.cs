using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IUsersAsyncService : IGenericAsyncService<User>
    {
        bool CreateUser(string username);
    }
}
