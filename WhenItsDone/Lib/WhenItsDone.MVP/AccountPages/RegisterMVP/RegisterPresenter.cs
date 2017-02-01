using WebFormsMvp;

using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.AccountPages.RegisterMVP
{
    public class RegisterPresenter : Presenter<IRegisterView>, IRegisterPresenter
    {
        private readonly IUsersAsyncService userService;

        public RegisterPresenter(IRegisterView view, IUsersAsyncService userService)
            : base(view)
        {
            this.userService = userService;

            this.View.Registration += this.OnRegister;
        }

        public void OnRegister(object sender, RegisterEventArgs args)
        {
            this.View.Model.RegistrationIsSuccessful = this.userService.CreateUser(args.Username);
        }
    }
}
