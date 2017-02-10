using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP
{
    public class UploadProfilePicturePresenter : Presenter<IUploadProfilePictureView>, IUploadProfilePicturePresenter
    {
        public UploadProfilePicturePresenter(IUploadProfilePictureView view)
            : base(view)
        {
            this.View.UploadProfilePicture += this.OnUploadProfilePicture;
            this.View.UploadProfilePictureFromUrl += this.OnUploadProfilePictureFromUrl;
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
