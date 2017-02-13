using System;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UpdateContactInformationMVP
{
    public class UpdateContactInformationInitialStateEventArgs : EventArgs
    {
        public UpdateContactInformationInitialStateEventArgs(string loggedUserUsername)
        {
            this.LoggedUserUsername = loggedUserUsername;
        }

        public string LoggedUserUsername { get; private set; }
    }
}
