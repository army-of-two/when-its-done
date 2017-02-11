using System;
using System.Web.UI;

namespace WhenItsDone.WebFormsClient.ViewControls.ManageUserControls
{
    public partial class UpdatePersonalInformationUserControl : System.Web.UI.UserControl
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.LoggedUserUsername.Value = Page.User.Identity.Name;
        }
    }
}