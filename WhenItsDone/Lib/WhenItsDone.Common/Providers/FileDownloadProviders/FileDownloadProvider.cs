using System;
using System.Net;

using WhenItsDone.Common.Providers.FileDownloadProviders.Contracts;

namespace WhenItsDone.Common.Providers.FileDownloadProviders
{
    public class FileDownloadProvider : IFileDownloadProvider
    {
        public string DownloadFileFromUrlToBase64(string sourceUrl)
        {
            string result;
            using (var client = new WebClient())
            {
                var arr = client.DownloadData(sourceUrl);
                result = Convert.ToBase64String(arr);

                client.Dispose();
            }

            if (string.IsNullOrEmpty(result))
            {
                throw new ArgumentException("Could not download file.");
            }
            else
            {
                return result;
            }
        }
    }
}
