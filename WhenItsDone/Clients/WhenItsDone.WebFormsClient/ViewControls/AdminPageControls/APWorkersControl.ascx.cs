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
        public event EventHandler GetWorkersNamesAndId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.GetWorkersNamesAndId?.Invoke(this, null);

                this.WorkersList.DataSource = this.Model.WorkersWithDishes;
                this.WorkersList.DataBind();
            }
        }

        protected void InfoClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
        }
    }
}