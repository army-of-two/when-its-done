using WebFormsMvp;

using WhenItsDone.MVP.Views.Home;

namespace WhenItsDone.MVP.Presenters.Home
{
    public class HomePresenter : Presenter<IHomeView>
    {
        public HomePresenter(IHomeView view)
            : base(view)
        {
        }
    }
}
