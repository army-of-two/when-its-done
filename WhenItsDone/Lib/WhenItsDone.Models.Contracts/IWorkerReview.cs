namespace WhenItsDone.Models.Contracts
{
    public interface IWorkerReview : IDbModel
    {
        string ReviewContent { get; set; }

        int Score { get; set; }

        int ClientId { get; set; }

        IClient Client { get; set; }
    }
}
