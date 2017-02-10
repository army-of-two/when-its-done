namespace WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP
{
    public class UploadProfilePictureEventArgs
    {
        public UploadProfilePictureEventArgs(byte[] uploadedFile)
        {
            this.UploadedFile = uploadedFile;
        }

        public byte[] UploadedFile { get; private set; }
    }
}
