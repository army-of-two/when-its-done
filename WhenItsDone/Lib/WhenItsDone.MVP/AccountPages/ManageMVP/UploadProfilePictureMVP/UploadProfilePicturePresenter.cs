using System;

using Bytes2you.Validation;

using WebFormsMvp;

using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP
{
    public class UploadProfilePicturePresenter : Presenter<IUploadProfilePictureView>, IUploadProfilePicturePresenter
    {
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
            throw new NotImplementedException();
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
