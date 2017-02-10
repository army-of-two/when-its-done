namespace WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP
{
    public class UploadProfilePictureFromUrlEventArgs
    {
        public UploadProfilePictureFromUrlEventArgs(string profilePictureUrl)
        {
            this.ProfilePictureUrl = profilePictureUrl;
        }

        public string ProfilePictureUrl { get; private set; }
    }
}
