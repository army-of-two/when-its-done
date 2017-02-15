namespace WhenItsDone.Models.Factories
{
    public interface IInitializedPhotoItemFactory
    {
        PhotoItem GetInitializedPhotoItem(string url, int userId);
    }
}
