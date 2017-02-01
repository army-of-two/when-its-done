using System;
using WhenItsDone.DefaultAuth;
using WhenItsDone.MVP.AccountPages.RegisterMVP;
using WhenItsDone.DefaultAuth.DefaultRegisterServices;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace WhenItsDone.WebFormsClient.Account
{
    [PresenterBinding(typeof(IRegisterPresenter))]
    public partial class Register : MvpPage<RegisterViewModel>, IRegisterView
    {
        public event EventHandler<DefaultRegisterEventArgs> DefaultRegistration;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var defaultRegisterEventArgs = new DefaultRegisterEventArgs(Context, Email.Text, Password.Text);
            this.DefaultRegistration?.Invoke(null, defaultRegisterEventArgs);

            if (this.Model.RegistrationIsSuccessful)
            {
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = this.Model.ErrorMessage;
            }
        }
    }
}