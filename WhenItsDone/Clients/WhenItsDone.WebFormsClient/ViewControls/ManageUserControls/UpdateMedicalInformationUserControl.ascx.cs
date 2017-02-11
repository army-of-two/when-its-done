using System;
using System.Web.UI;

namespace WhenItsDone.WebFormsClient.ViewControls.ManageUserControls
{
    public partial class UpdateMedicalInformationUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoggedUserUsername.Value = Page.User.Identity.Name;
        }
    }
}