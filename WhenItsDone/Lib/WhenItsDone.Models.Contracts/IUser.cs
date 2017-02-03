using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public interface IUser : IDbModel
    {
        string Username { get; set; }

        int ClientId { get; set; }

        IClient Client { get; set; }

        int WorkerId { get; set; }

        IWorker Worker { get; set; }
    }
}
