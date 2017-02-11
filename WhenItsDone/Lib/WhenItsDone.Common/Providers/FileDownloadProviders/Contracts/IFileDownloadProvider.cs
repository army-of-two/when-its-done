namespace WhenItsDone.Common.Providers.FileDownloadProviders.Contracts
{
    public interface IFileDownloadProvider
    {
        string DownloadFileFromUrlToBase64(string sourceUrl);
    }
}
