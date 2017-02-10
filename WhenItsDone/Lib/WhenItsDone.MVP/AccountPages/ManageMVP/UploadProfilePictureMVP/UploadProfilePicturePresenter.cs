using System;

using Bytes2you.Validation;

using WebFormsMvp;

using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP
{
    public class UploadProfilePicturePresenter : Presenter<IUploadProfilePictureView>, IUploadProfilePicturePresenter
    {
        private const string UserNotFoundErrorText = "User with Username: {0} was not found.";

        private IUsersAsyncService usersService;

        public UploadProfilePicturePresenter(IUploadProfilePictureView view, IUsersAsyncService usersService)
            : base(view)
        {
            Guard.WhenArgument(usersService, nameof(IUsersAsyncService)).IsNull().Throw();

            this.usersService = usersService;

            this.View.InitialState += this.OnInitialState;
            this.View.UploadProfilePicture += this.OnUploadProfilePicture;
            this.View.UploadProfilePictureFromUrl += this.OnUploadProfilePictureFromUrl;
        }

        public void OnInitialState(object sender, UploadProfilePictureInitialStateEventArgs args)
        {
            Guard.WhenArgument(args, nameof(UploadProfilePictureEventArgs)).IsNull().Throw();
            Guard.WhenArgument(args.LoggedUserUsername, nameof(args.LoggedUserUsername)).IsNullOrEmpty().Throw();

            var foundUserView = this.usersService.GetCurrentUserProfilePicture(args.LoggedUserUsername);
            if (foundUserView != null)
            {
                this.View.Model.IsSuccessful = true;
                this.View.Model.CurrentProfilePictureBase64 = foundUserView.ProfilePictureBase64;
                this.View.Model.CurrentProfilePictureMimeType = foundUserView.ProfilePictureExtension;
            }
        }

        public void OnUploadProfilePicture(object sender, UploadProfilePictureEventArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnUploadProfilePictureFromUrl(object sender, UploadProfilePictureFromUrlEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
