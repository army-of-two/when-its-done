using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;

using WhenItsDone.DefaultAuth;
using WhenItsDone.MVP.AccountPages.RegisterMVP;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace WhenItsDone.WebFormsClient.Account
{
    [PresenterBinding(typeof(IRegisterPresenter))]
    public partial class Register : MvpPage<RegisterViewModel>, IRegisterView
    {
        public event EventHandler<RegisterEventArgs> Registration;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                // Plugin Custom Event Here
                var registerEventArgs = new RegisterEventArgs(user.UserName);
                this.Registration?.Invoke(null, registerEventArgs);

                if (!this.Model.RegistrationIsSuccessful)
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                    return;
                }

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}