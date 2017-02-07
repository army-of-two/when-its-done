using System;

namespace WhenItsDone.DefaultAuth.DefaultRegisterServices
{
    public class DefaultRegisterOperationCompleteEventArgs : EventArgs
    {
        public DefaultRegisterOperationCompleteEventArgs(Guid aspUserId, string username, bool registerIsSuccessful, string errorMessage)
        {
            this.AspNetUserId = aspUserId;
            this.Username = username;
            this.RegisterIsSuccessful = registerIsSuccessful;
            this.ErrorMessage = errorMessage;
        }

        public string Username { get; private set; }

        public Guid AspNetUserId { get; private set; }

        public bool RegisterIsSuccessful { get; private set; }

        public string ErrorMessage { get; private set; }
    }
}
