using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WhenItsDone.WebFormsClient.ViewControls.Contracts;

namespace WhenItsDone.WebFormsClient.ViewControls.ManageUserControls
{
    public partial class UpdateContactInformationUserControl : System.Web.UI.UserControl, IShouldLoad
    {
        public bool ShouldLoad { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.ShouldLoad)
            {

            }
        }
    }
}