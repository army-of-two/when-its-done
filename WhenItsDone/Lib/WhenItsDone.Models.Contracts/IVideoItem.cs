namespace WhenItsDone.Models.Contracts
{
    public interface IVideoItem : IDbModel
    {
        string Url { get; set; }
    }
}
