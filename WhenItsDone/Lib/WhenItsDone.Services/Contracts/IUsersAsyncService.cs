using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IUsersAsyncService : IGenericAsyncService<User>
    {
        User CreateUser(string username);
    }
}
