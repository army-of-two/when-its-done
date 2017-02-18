using System;

namespace WhenItsDone.MVP.AdminPageControls.EventArguments
{
    public class StringEventArgs : EventArgs
    {
        public StringEventArgs()
        {

        }

        public StringEventArgs(string stringParameter)
        {
            this.StringParameter = stringParameter;
        }

        public string StringParameter { get; set; }
    }
}
