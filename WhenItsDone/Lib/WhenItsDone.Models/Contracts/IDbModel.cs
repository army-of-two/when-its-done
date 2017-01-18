namespace WhenItsDone.Models.Contracts
{
    public interface IDbModel
    {
        int Id { get; }

        bool IsDeleted { get; }
    }
}
