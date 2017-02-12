using System;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UpdateContactInformationMVP
{
    public class UpdateContactInformationUpdateValuesEventArgs : EventArgs
    {
        public UpdateContactInformationUpdateValuesEventArgs(string loggedUserUsername, string country, string city, string street)
        {
            this.LoggedUserUsername = loggedUserUsername;
            this.Country = country;
            this.City = city;
            this.Street = street;
        }

        public string LoggedUserUsername { get; private set; }

        public string Country { get; private set; }

        public string City { get; private set; }

        public string Street { get; private set; }
    }
}
