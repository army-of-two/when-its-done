using System;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using WhenItsDone.DefaultAuth;

namespace WhenItsDone.WebFormsClient.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void ProfilePictureButton_Click(object sender, EventArgs e)
        {
            this.Test.Visible = !this.Test.Visible;
        }
    }
}