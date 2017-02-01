using System;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace WhenItsDone.DefaultAuth.DefaultRegisterServices
{
    public class DefaultRegisterService : IDefaultRegisterService
    {
        public event EventHandler<DefaultRegisterCompleteOperationEventArgs> OperationComplete;

        public void OnDefaultRegister(object sender, DefaultRegisterEventArgs args)
        {
            var manager = args.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = args.Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = args.Email, Email = args.Email };
            IdentityResult result = manager.Create(user, args.Password);

            if (result.Succeeded)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
            }

            var defaultRegisterCompleteOperationEventArgs = new DefaultRegisterCompleteOperationEventArgs(result.Succeeded, user.UserName);
            this.OperationComplete(null, defaultRegisterCompleteOperationEventArgs);
        }
    }
}
