using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP
{
    public interface IUploadProfilePictureView : IView<UploadProfilePictureViewModel>
    {
        event EventHandler<UploadProfilePictureEventArgs> UploadProfilePicture;

        event EventHandler<UploadProfilePictureFromUrlEventArgs> UploadProfilePictureFromUrl;

        event EventHandler<UploadProfilePictureInitialStateEventArgs> InitialState;
    }
}
