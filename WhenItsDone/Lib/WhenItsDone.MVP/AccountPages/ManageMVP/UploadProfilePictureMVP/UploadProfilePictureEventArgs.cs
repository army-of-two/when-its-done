namespace WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP
{
    public class UploadProfilePictureEventArgs
    {
        public UploadProfilePictureEventArgs(string loggedUserUsername, string uploadedFileName, byte[] uploadedFile)
        {
            this.LoggedUserUsername = loggedUserUsername;
            this.UploadedFileName = uploadedFileName;
            this.UploadedFile = uploadedFile;
        }

        public string LoggedUserUsername { get; private set; }

        public string UploadedFileName { get; private set; }

        public byte[] UploadedFile { get; private set; }
    }
}
