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

            try
            {
                var foundUserView = this.usersService.GetCurrentUserProfilePicture(args.LoggedUserUsername);
                if (foundUserView != null)
                {
                    this.View.Model.IsSuccessful = true;
                    this.View.Model.CurrentProfilePictureBase64 = foundUserView.ProfilePictureBase64;
                    this.View.Model.CurrentProfilePictureMimeType = foundUserView.ProfilePictureExtension;
                }
                else
                {
                    this.View.Model.IsSuccessful = false;
                    this.View.Model.ResultText = string.Format(UploadProfilePicturePresenter.UserNotFoundErrorText, args.LoggedUserUsername);
                }

            }
            catch (Exception ex)
            {
                this.View.Model.IsSuccessful = false;
                this.View.Model.ResultText = ex.Message;
            }
        }

        public void OnUploadProfilePicture(object sender, UploadProfilePictureEventArgs args)
        {
            Guard.WhenArgument(args, nameof(args)).IsNull().Throw();
            Guard.WhenArgument(args.LoggedUserUsername, nameof(args.LoggedUserUsername)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(args.UploadedFileName, nameof(args.UploadedFileName)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(args.UploadedFile, nameof(args.UploadedFile)).IsNull().Throw();

            try
            {
                var updatedUser = this.usersService.UpdateUserProfilePicture(args.LoggedUserUsername, args.UploadedFileName, args.UploadedFile);
                if (updatedUser == null)
                {
                    throw new ArgumentException("User could not be found.");
                }
                else
                {
                    this.View.Model.IsSuccessful = true;
                    this.View.Model.CurrentProfilePictureBase64 = updatedUser.ProfilePicture.PictureBase64;
                    this.View.Model.CurrentProfilePictureMimeType = updatedUser.ProfilePicture.MimeType;
                    this.View.Model.ResultText = "Successfully updated profile picture";
                }
            }
            catch (Exception ex)
            {
                this.View.Model.IsSuccessful = false;
                this.View.Model.ResultText = ex.Message;
            }
        }

        public void OnUploadProfilePictureFromUrl(object sender, UploadProfilePictureFromUrlEventArgs args)
        {
            Guard.WhenArgument(args, nameof(args)).IsNull().Throw();
            Guard.WhenArgument(args.LoggedUserUsername, nameof(args.LoggedUserUsername)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(args.ProfilePictureUrl, nameof(args.ProfilePictureUrl)).IsNullOrEmpty().Throw();

            try
            {
                var updatedUser = this.usersService.UpdateUserProfilePictureFromUrl(args.LoggedUserUsername, args.ProfilePictureUrl);
                if (updatedUser == null)
                {
                    throw new ArgumentException("User could not be found.");
                }
                else
                {
                    this.View.Model.IsSuccessful = true;
                    this.View.Model.CurrentProfilePictureBase64 = updatedUser.ProfilePicture.PictureBase64;
                    this.View.Model.CurrentProfilePictureMimeType = updatedUser.ProfilePicture.MimeType;
                    this.View.Model.ResultText = "Successfully updated profile picture";
                }
            }
            catch (Exception ex)
            {
                this.View.Model.IsSuccessful = false;
                this.View.Model.ResultText = ex.Message;
            }
        }
    }
}
