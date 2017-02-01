using WebFormsMvp;

using WhenItsDone.DefaultAuth.DefaultRegisterServices;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.AccountPages.RegisterMVP
{
    public class RegisterPresenter : Presenter<IRegisterView>, IRegisterPresenter
    {
        private readonly IUsersAsyncService userService;

        public RegisterPresenter(IRegisterView view, IUsersAsyncService userService, IDefaultRegisterService defaultRegisterService)
            : base(view)
        {
            this.userService = userService;
            
            this.View.DefaultRegistration += defaultRegisterService.OnDefaultRegister;
            defaultRegisterService.OperationComplete += this.OnDefaultRegisterOperationComplete;
        }
        
        public void OnDefaultRegisterOperationComplete(object sender, DefaultRegisterOperationCompleteEventArgs args)
        {
            this.View.Model.RegistrationIsSuccessful = this.userService.CreateUser(args.Username);
        }
    }
}