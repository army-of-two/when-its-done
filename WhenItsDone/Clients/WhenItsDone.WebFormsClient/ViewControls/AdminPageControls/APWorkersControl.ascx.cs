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
using WhenItsDone.MVP.AdminPageControls.EventArguments;

namespace WhenItsDone.WebFormsClient.ViewControls.AdminPageControls
{
    [PresenterBinding(typeof(IAPWorkersControlPresenter))]
    public partial class APWorkersControl : MvpUserControl<APWorkersControlViewModel>, IAPWorkersControlView
    {
        public event EventHandler GetWorkersNamesAndId;
        public event EventHandler<StringEventArgs> UserClickedInfoButton;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.GetWorkersNamesAndId?.Invoke(this, null);

                this.WorkersList.DataSource = this.Model.WorkersNamesAndId;
                this.WorkersList.DataBind();
            }
        }

        public void GetWorkersFireEvent()
        {
            this.GetWorkersNamesAndId?.Invoke(this, EventArgs.Empty);
        }

        protected void InfoClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            var args = new StringEventArgs(btn.CommandArgument);

            UserClickedInfoButton?.Invoke(this, args);
        }
    }
}