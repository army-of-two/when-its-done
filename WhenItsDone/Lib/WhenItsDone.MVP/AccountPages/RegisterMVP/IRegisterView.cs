using System;

using WebFormsMvp;

using WhenItsDone.DefaultAuth.DefaultRegisterServices;

namespace WhenItsDone.MVP.AccountPages.RegisterMVP
{
    public interface IRegisterView : IView<RegisterViewModel>
    {
        event EventHandler<DefaultRegisterEventArgs> DefaultRegistration;
    }
}
