using System;

using WebFormsMvp;

using WhenItsDone.MVP.Models.Home;

namespace WhenItsDone.MVP.Views.Home
{
    public interface IHomeView : IView<HomeViewModel>
    {
        event EventHandler MoreInformation;
    }
}
