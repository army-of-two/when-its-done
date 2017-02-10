namespace WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP
{
    public class UploadProfilePictureInitialStateEventArgs
    {
        public UploadProfilePictureInitialStateEventArgs(string loggedUserUsername)
        {
            this.LoggedUserUsername = loggedUserUsername;
        }

        public string LoggedUserUsername { get; private set; }
    }
}
