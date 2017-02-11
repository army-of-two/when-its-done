using System;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UpdateMedicalInformationMVP
{
    public class UpdateMedicalInformationUpdateValuesEventArgs : EventArgs
    {
        public UpdateMedicalInformationUpdateValuesEventArgs(string loggedUserUsername, string heightInCm, string weightInKg)
        {
            this.LoggedUserUsername = loggedUserUsername;
            this.HeightInCm = heightInCm;
            this.WeightInKg = weightInKg;
        }

        public string LoggedUserUsername { get; private set; }

        public string HeightInCm { get; private set; }

        public string WeightInKg { get; private set; }
    }
}
