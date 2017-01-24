using WebFormsMvp;

using WhenItsDone.MVP.Presenters.Contracts;
using WhenItsDone.MVP.Views.Home;

namespace WhenItsDone.MVP.Presenters.Home
{
    public class HomePresenter : Presenter<IHomeView>, IHomePresenter
    {
        public HomePresenter(IHomeView view)
            : base(view)
        {
        }
    }
}
