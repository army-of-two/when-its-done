namespace WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP
{
    public class UploadProfilePictureViewModel
    {
        public string CurrentProfilePictureBase64 { get; set; }

        public string CurrentProfilePictureMimeType { get; set; }

        public string LoggedUserUsername { get; set; }

        public string ResultText { get; set; }

        public bool IsSuccessful { get; set; }
    }
}
