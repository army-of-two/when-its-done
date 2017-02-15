using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.CreatePages
{
    public interface ICreateView : IView<CreateViewModel>
    {
        event EventHandler<CreateEventArgs> CreateDish;
    }
}
