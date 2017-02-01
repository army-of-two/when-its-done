using WebFormsMvp;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.AccountPages.RegisterMVP
{
    public class RegisterPresenter : Presenter<IRegisterView>, IRegisterPresenter
    {
        private readonly IUserAsyncService userService;

        public RegisterPresenter(IRegisterView view, IUserAsyncService userService)
            : base(view)
        {
            this.userService = userService;

            this.View.Registration += this.OnRegister;
        }

        public void OnRegister(object sender, RegisterEventArgs args)
        {

        }
    }
}
