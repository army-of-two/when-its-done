namespace WhenItsDone.Models.Factories
{
    public interface IInitializedVideoItemFactory
    {
        VideoItem GetInitializedVideoItem(string youTubeUrl);
    }
}
