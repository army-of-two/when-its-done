using WebFormsMvp;

namespace WhenItsDone.MVP.CreatePages
{
    public class CreatePresenter : Presenter<ICreateView>, ICreatePresenter
    {
        public CreatePresenter(ICreateView view)
            : base(view)
        {
            this.View.CreateDish += this.OnCreateDish;
        }

        public void OnCreateDish(object sender, CreateEventArgs args)
        {

        }
    }
}
