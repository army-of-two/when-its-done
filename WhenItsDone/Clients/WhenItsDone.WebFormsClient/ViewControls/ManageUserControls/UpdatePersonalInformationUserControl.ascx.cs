using System;
using System.Web.UI;

using WhenItsDone.WebFormsClient.ViewControls.Contracts;

namespace WhenItsDone.WebFormsClient.ViewControls.ManageUserControls
{
    public partial class UpdatePersonalInformationUserControl : System.Web.UI.UserControl, IShouldLoad
    {
        public bool ShouldLoad { get; set; }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.LoggedUserUsername.Value = Page.User.Identity.Name;
        }
    }
}