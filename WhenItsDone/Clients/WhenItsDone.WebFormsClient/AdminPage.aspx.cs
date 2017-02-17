using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhenItsDone.WebFormsClient
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.APWorkersControl.UserClickedInfoButton += APWorkersControl_UserClickedInfoButton;
        }

        private void APWorkersControl_UserClickedInfoButton(object sender, string e)
        {

            this.APWorkersControl.Visible = false;
            // Call right user control here
        }
    }
}