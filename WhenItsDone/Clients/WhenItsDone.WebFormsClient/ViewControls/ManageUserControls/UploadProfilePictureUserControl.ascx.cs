using System;
using WebFormsMvp;
using WebFormsMvp.Web;

using WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP;

namespace WhenItsDone.WebFormsClient.ViewControls.ManageUserControls
{
    [PresenterBinding(typeof(IUploadProfilePicturePresenter))]
    public partial class UploadProfilePictureUserControl : MvpUserControl<UploadProfilePictureViewModel>, IUploadProfilePictureView
    {
        public event EventHandler<UploadProfilePictureEventArgs> UploadProfilePicture;
        public event EventHandler<UploadProfilePictureFromUrlEventArgs> UploadProfilePictureFromUrl;

        public void OnUploadProfilePictureButtonClick(object sender, EventArgs args)
        {
            var loggedUserUsername = Page.User.Identity.Name;
            if (this.ProfilePictureFileUpload.HasFile)
            {
                var uploadedFile = this.ProfilePictureFileUpload.FileBytes;
                var uploadedFileName = this.ProfilePictureFileUpload.FileName;

                var uploadProfilePictureEventArgs = new UploadProfilePictureEventArgs(loggedUserUsername, uploadedFileName, uploadedFile);
                this.UploadProfilePicture?.Invoke(null, uploadProfilePictureEventArgs);
            }
        }
    }
}