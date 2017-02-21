using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP;
using WhenItsDone.WebFormsClient.ViewControls.Contracts;

namespace WhenItsDone.WebFormsClient.ViewControls.ManageUserControls
{
    [PresenterBinding(typeof(IUploadProfilePicturePresenter))]
    public partial class UploadProfilePictureUserControl : MvpUserControl<UploadProfilePictureViewModel>, IUploadProfilePictureView, IShouldLoad
    {
        public event EventHandler<UploadProfilePictureEventArgs> OnUploadProfilePicture;
        public event EventHandler<UploadProfilePictureFromUrlEventArgs> OnUploadProfilePictureFromUrl;
        public event EventHandler<UploadProfilePictureInitialStateEventArgs> OnInitialState;

        public bool ShouldLoad { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.ProfilePictureUrlTextBox.Value = string.Empty;

            var loggedUserUsername = Page.User.Identity.Name;
            this.Model.LoggedUserUsername = loggedUserUsername;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (this.ShouldLoad)
            {
                var uploadProfilePictureInitialStateEventArgs = new UploadProfilePictureInitialStateEventArgs(this.Model.LoggedUserUsername);
                this.OnInitialState?.Invoke(null, uploadProfilePictureInitialStateEventArgs);

                if (!this.Model.IsSuccessful)
                {
                    this.DisplayResultError(this.Model.ResultText);
                }
            }
        }

        public void OnUploadProfilePictureButtonClick(object sender, EventArgs args)
        {
            var loggedUserUsername = this.Model.LoggedUserUsername;
            if (this.ProfilePictureFileUpload.HasFile)
            {
                var uploadedFile = this.ProfilePictureFileUpload.FileBytes;
                var uploadedFileName = this.ProfilePictureFileUpload.FileName;

                var uploadProfilePictureEventArgs = new UploadProfilePictureEventArgs(loggedUserUsername, uploadedFileName, uploadedFile);
                this.OnUploadProfilePicture?.Invoke(null, uploadProfilePictureEventArgs);
            }
            else if (!string.IsNullOrEmpty(this.ProfilePictureUrlTextBox.Value))
            {
                var profilePictureUrl = this.ProfilePictureUrlTextBox.Value;

                var uploadProfilePictureFromUrlEventArgs = new UploadProfilePictureFromUrlEventArgs(loggedUserUsername, profilePictureUrl);
                this.OnUploadProfilePictureFromUrl?.Invoke(null, uploadProfilePictureFromUrlEventArgs);
            }
            else
            {
                var uploadProfilePictureInitialStateEventArgs = new UploadProfilePictureInitialStateEventArgs(this.Model.LoggedUserUsername);
                this.OnInitialState?.Invoke(null, uploadProfilePictureInitialStateEventArgs);
                this.Model.IsSuccessful = false;
            }

            if (!this.Model.IsSuccessful)
            {
                this.DisplayResultError(this.Model.ResultText);
            }
            else
            {
                this.DisplayResultSuccess(this.Model.ResultText);
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