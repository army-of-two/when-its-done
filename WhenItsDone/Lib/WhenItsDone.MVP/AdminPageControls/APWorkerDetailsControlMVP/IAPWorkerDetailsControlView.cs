using System;
using WebFormsMvp;
using WhenItsDone.MVP.AdminPageControls.EventArguments;

namespace WhenItsDone.MVP.AdminPageControls.APWorkerDetailsControlMVP
{
    public interface IAPWorkerDetailsControlView : IView<APWorkerDetailsControlViewModel>
    {
        event EventHandler<StringEventArgs> GetWorkerDetailsById;
    }
}
