namespace WhenItsDone.Models.Contracts
{
    public interface IReceivedPayment : IDbModel
    {
        int ClientId { get; set; }

        IClient Client { get; set; }

        decimal AmountPaid { get; set; }
    }
}
