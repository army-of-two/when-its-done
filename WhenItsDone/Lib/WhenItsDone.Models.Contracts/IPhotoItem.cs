namespace WhenItsDone.Models.Contracts
{
    public interface IPhotoItem : IDbModel
    {
        string Url { get; set; }
    }
}
