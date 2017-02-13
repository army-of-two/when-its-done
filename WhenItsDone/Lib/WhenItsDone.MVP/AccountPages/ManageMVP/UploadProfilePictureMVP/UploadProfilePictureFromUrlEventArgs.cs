using System;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP
{
    public class UploadProfilePictureFromUrlEventArgs : EventArgs
    {
        public UploadProfilePictureFromUrlEventArgs(string loggedUserUsername, string profilePictureUrl)
        {
            this.LoggedUserUsername = loggedUserUsername;
            this.ProfilePictureUrl = profilePictureUrl;
        }

        public string LoggedUserUsername { get; set; }

        public string ProfilePictureUrl { get; private set; }
    }
}
