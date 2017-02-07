using Bytes2you.Validation;
using System;
using WebFormsMvp;

using WhenItsDone.DefaultAuth.DefaultRegisterServices;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.AccountPages.RegisterMVP
{
    public class RegisterPresenter : Presenter<IRegisterView>, IRegisterPresenter
    {
        private readonly IUsersRegistrationAsyncService userService;

        public RegisterPresenter(IRegisterView view, IUsersRegistrationAsyncService userService, IDefaultRegisterService defaultRegisterService)
            : base(view)
        {
            Guard.WhenArgument(userService, nameof(IUsersRegistrationAsyncService)).IsNull().Throw();
            Guard.WhenArgument(defaultRegisterService, nameof(IDefaultRegisterService)).IsNull().Throw();

            this.userService = userService;

            this.View.DefaultRegister += defaultRegisterService.OnDefaultRegister;
            defaultRegisterService.OperationComplete += this.OnDefaultRegisterOperationComplete;
        }

        public void OnDefaultRegisterOperationComplete(object sender, DefaultRegisterOperationCompleteEventArgs args)
        {
            Guard.WhenArgument(args, nameof(DefaultRegisterOperationCompleteEventArgs)).IsNull().Throw();
            Guard.WhenArgument(args.Username, "DefaultRegisterOperationCompleteEventArgs.Username is null or empty.").IsNullOrEmpty().Throw();

            this.View.Model.RegisterIsSuccessful = args.RegisterIsSuccessful;
            if (this.View.Model.RegisterIsSuccessful)
            {
                this.View.Model.RegisterIsSuccessful = this.userService.CreateUser(args.AspNetUserId, args.Username);
            }
            else
            {
                this.View.Model.ErrorMessage = args.ErrorMessage;
            }
        }
    }
}