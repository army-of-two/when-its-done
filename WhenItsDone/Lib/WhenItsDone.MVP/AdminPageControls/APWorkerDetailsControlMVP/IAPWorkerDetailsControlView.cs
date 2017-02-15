using System;
using WebFormsMvp;

namespace WhenItsDone.MVP.AdminPageControls.APWorkerDetailsControlMVP
{
    public interface IAPWorkerDetailsControlView : IView<APWorkerDetailsControlViewModel>
    {
        event EventHandler<string> GetWorkerDetailsById;
    }
}
