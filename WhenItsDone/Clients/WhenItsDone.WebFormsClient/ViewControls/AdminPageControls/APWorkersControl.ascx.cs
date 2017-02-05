using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.MVP.AdminPageControls.APWorkersControlMVP;

namespace WhenItsDone.WebFormsClient.ViewControls.AdminPageControls
{
    [PresenterBinding(typeof(IAPWorkersControlPresenter))]
    public partial class APWorkersControl : MvpUserControl<APWorkersControlViewModel>, IAPWorkersControlView
    {
        public event EventHandler GetWorkersWithDishes;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}