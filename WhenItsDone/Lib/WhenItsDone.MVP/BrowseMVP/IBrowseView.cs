using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.BrowseMVP
{
    public interface IBrowseView : IView<BrowseViewModel>
    {
        event EventHandler BrowseDishesGetData;
    }
}
