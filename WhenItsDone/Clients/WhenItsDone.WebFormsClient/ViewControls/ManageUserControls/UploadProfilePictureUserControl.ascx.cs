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
            else if (this.ProfilePictureUrlTextBox.Text != null)
            {
                var profilePictureUrl = this.ProfilePictureUrlTextBox.Text;

                var uploadProfilePictureFromUrlEventArgs = new UploadProfilePictureFromUrlEventArgs(loggedUserUsername, profilePictureUrl);
                this.UploadProfilePictureFromUrl?.Invoke(null, uploadProfilePictureFromUrlEventArgs);
            }
            else
            {
                this.DisplayResultError("Something went wrong!");
            }
        }

        private void DisplayResultError(string errorText)
        {
            this.ResultLable.Visible = true;
            this.ResultLable.CssClass = "result-error";
            this.ResultLable.Text = errorText ?? "Something went wrong!";
        }

        private void DisplayResultSuccess(string successText)
        {
            this.ResultLable.Visible = true;
            this.ResultLable.CssClass = "result-success";
            this.ResultLable.Text = successText ?? "Something went right!";
        }

        private void HideResult()
        {
            this.ResultLable.Visible = false;
            this.ResultLable.CssClass = "";
            this.ResultLable.Text = "";
        }
    }
}