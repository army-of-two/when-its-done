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
        public event EventHandler<DefaultRegisterEventArgs> DefaultRegister;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var defaultRegisterEventArgs = new DefaultRegisterEventArgs(this.Context, this.Email.Text, this.Password.Text);
            this.DefaultRegister?.Invoke(null, defaultRegisterEventArgs);

            if (this.Model.RegisterIsSuccessful)
            {
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                this.ErrorMessage.Text = this.Model.ErrorMessage ?? "Try Again!";
            }
        }
    }
}