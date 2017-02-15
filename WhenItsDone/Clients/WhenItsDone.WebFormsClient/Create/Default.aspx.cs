using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using WhenItsDone.MVP.CreatePages;

namespace WhenItsDone.WebFormsClient.Create
{
    [PresenterBinding(typeof(ICreatePresenter))]
    public partial class Default : MvpPage<CreateViewModel>, ICreateView
    {
        public event EventHandler<CreateEventArgs> CreateDish;

        public void OnCreateFormSubmit(object sender, EventArgs e)
        {
            
        }
    }
}