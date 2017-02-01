namespace WhenItsDone.Models.Contracts
{
    public interface IAddress : IDbModel
    {
        string Country { get; set; }

        string City { get; set; }

        string Street { get; set; }
    }
}
