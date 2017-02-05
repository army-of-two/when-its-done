using Bytes2you.Validation;

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
            Guard.WhenArgument(userService, nameof(IUsersAsyncService)).IsNull();
            Guard.WhenArgument(defaultRegisterService, nameof(IDefaultRegisterService)).IsNull();

            this.userService = userService;

            this.View.DefaultRegister += defaultRegisterService.OnDefaultRegister;
            defaultRegisterService.OperationComplete += this.OnDefaultRegisterOperationComplete;
        }

        public void OnDefaultRegisterOperationComplete(object sender, DefaultRegisterOperationCompleteEventArgs args)
        {
            Guard.WhenArgument(args, nameof(DefaultRegisterOperationCompleteEventArgs)).IsNull();
            Guard.WhenArgument(args.Username, "DefaultRegisterOperationCompleteEventArgs.Username is null or empty.").IsNullOrEmpty();

            this.View.Model.RegisterIsSuccessful = args.RegisterIsSuccessful;
            if (this.View.Model.RegisterIsSuccessful)
            {
                this.View.Model.RegisterIsSuccessful = this.userService.CreateUser(args.Username);
            }
            else
            {
                this.View.Model.ErrorMessage = args.ErrorMessage;
            }
        }
    }
}