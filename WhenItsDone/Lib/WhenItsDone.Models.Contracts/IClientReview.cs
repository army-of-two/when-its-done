namespace WhenItsDone.Models.Contracts
{
    public interface IClientReview : IDbModel
    {
        string ReviewContent { get; set; }

        int Score { get; set; }

        int WorkerId { get; set; }

        IWorker Worker { get; set; }
    }
}
