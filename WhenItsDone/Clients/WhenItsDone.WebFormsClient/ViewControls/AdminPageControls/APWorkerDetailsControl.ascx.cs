using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhenItsDone.MVP.AdminPageControls.APWorkerDetailsControlMVP;

namespace WhenItsDone.WebFormsClient.ViewControls.AdminPageControls
{
    [PresenterBinding(typeof(APWorkerDetailsPresenter))]
    public partial class APWorkerDetails : MvpUserControl<APWorkerDetailsControlViewModel>, IAPWorkerDetailsControlView
    {
        public event EventHandler<string> GetWorkerDetailsById;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}