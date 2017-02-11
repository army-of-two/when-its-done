using System;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UpdateMedicalInformationMVP
{
    public class UpdateMedicalInformationInitialStateEventArgs : EventArgs
    {
        public UpdateMedicalInformationInitialStateEventArgs(string loggedUserUsername)
        {
            this.LoggedUserUsername = loggedUserUsername;
        }

        public string LoggedUserUsername { get; private set; }
    }
}
