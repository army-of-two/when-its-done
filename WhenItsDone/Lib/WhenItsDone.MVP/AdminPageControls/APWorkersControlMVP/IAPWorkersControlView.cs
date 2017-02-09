using System;
using WebFormsMvp;

namespace WhenItsDone.MVP.AdminPageControls.APWorkersControlMVP
{
    public interface IAPWorkersControlView : IView<APWorkersControlViewModel>
    {
        event EventHandler GetWorkersNamesAndId;
    }
}
