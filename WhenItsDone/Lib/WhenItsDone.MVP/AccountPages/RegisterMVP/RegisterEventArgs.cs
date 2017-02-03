using System;

namespace WhenItsDone.MVP.AccountPages.RegisterMVP
{
    public class RegisterEventArgs : EventArgs
    {
        public RegisterEventArgs(string username)
        {
            this.Username = username;
        }

        public string Username { get; private set; }
    }
}
