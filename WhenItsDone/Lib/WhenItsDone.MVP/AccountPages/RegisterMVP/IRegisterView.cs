using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.AccountPages.RegisterMVP
{
    public interface IRegisterView : IView<RegisterViewModel>
    {
        event EventHandler<RegisterEventArgs> Registration;
    }
}
