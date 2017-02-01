using System;

namespace WhenItsDone.DefaultAuth.DefaultRegisterServices
{
    public class DefaultRegisterOperationCompleteEventArgs : EventArgs
    {
        public DefaultRegisterOperationCompleteEventArgs(string username, bool registerIsSuccessful, string errorMessage)
        {
            this.Username = username;
            this.RegisterIsSuccessful = registerIsSuccessful;
            this.ErrorMessage = errorMessage;
        }

        public string Username { get; private set; }

        public bool RegisterIsSuccessful { get; private set; }

        public string ErrorMessage { get; private set; }
    }
}
