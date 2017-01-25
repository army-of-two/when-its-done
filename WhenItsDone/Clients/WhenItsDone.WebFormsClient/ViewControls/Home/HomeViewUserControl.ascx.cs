using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using WhenItsDone.MVP.Models.Home;
using WhenItsDone.MVP.Presenters.Contracts;
using WhenItsDone.MVP.Views.Home;

namespace WhenItsDone.WebFormsClient.ViewControls.Home
{
    [PresenterBinding(typeof(IHomePresenter))]
    public partial class HomeViewUserControl : MvpUserControl<HomeViewModel>, IHomeView
    {
        public event EventHandler MoreInformation;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}