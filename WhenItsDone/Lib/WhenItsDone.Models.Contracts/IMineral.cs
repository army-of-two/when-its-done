namespace WhenItsDone.Models.Contracts
{
    public interface IMineral : IDbModel
    {
        decimal Quantity { get; set; }

        string Name { get; set; }
    }
}