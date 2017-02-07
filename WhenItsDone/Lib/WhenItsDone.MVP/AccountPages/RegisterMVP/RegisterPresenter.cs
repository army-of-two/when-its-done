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
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(IUsersRegistrationAsyncService));
            }

            if (defaultRegisterService == null)
            {
                throw new ArgumentNullException(nameof(IDefaultRegisterService));
            }

            this.userService = userService;

            this.View.DefaultRegister += defaultRegisterService.OnDefaultRegister;
            defaultRegisterService.OperationComplete += this.OnDefaultRegisterOperationComplete;
        }

        public void OnDefaultRegisterOperationComplete(object sender, DefaultRegisterOperationCompleteEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(DefaultRegisterOperationCompleteEventArgs));
            }

            if (string.IsNullOrEmpty(args.Username))
            {
                throw new ArgumentException("Username must not be null or empty.");
            }

            if (args.AspNetUserId == default(Guid))
            {
                throw new ArgumentException("AspNetUserId must be different than Guid default value.");
            }

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