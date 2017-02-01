using System;

namespace WhenItsDone.DefaultAuth.DefaultRegisterServices
{
    public class DefaultRegisterCompleteOperationEventArgs : EventArgs
    {
        public DefaultRegisterCompleteOperationEventArgs(bool regiterIsSuccessful, string username)
        {
            this.RegiterIsSuccessful = regiterIsSuccessful;
            this.Username = username;
        }

        public bool RegiterIsSuccessful { get; private set; }

        public string Username { get; private set; }
    }
}
