using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP
{
    public interface IUploadProfilePictureView : IView<UploadProfilePictureViewModel>
    {
        event EventHandler<UploadProfilePictureEventArgs> OnUploadProfilePicture;

        event EventHandler<UploadProfilePictureFromUrlEventArgs> OnUploadProfilePictureFromUrl;

        event EventHandler<UploadProfilePictureInitialStateEventArgs> OnInitialState;
    }
}
