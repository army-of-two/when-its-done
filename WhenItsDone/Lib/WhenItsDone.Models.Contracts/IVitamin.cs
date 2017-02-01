namespace WhenItsDone.Models.Contracts
{
    public interface IVitamin : IDbModel
    {
        decimal Quantity { get; set; }

        string Name { get; set; }
    }
}
