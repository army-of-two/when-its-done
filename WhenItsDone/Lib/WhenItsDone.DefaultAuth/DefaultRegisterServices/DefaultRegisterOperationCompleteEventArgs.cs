using System;

namespace WhenItsDone.DefaultAuth.DefaultRegisterServices
{
    public class DefaultRegisterOperationCompleteEventArgs : EventArgs
    {
        public DefaultRegisterOperationCompleteEventArgs(bool registerIsSuccessful, string username)
        {
            this.RegisterIsSuccessful = registerIsSuccessful;
            this.Username = username;
        }

        public bool RegisterIsSuccessful { get; private set; }

        public string Username { get; private set; }
    }
}
