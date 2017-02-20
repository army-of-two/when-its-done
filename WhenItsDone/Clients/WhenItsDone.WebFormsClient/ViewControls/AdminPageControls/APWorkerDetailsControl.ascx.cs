using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhenItsDone.MVP.AdminPageControls.APWorkerDetailsControlMVP;
using WhenItsDone.MVP.AdminPageControls.EventArguments;

namespace WhenItsDone.WebFormsClient.ViewControls.AdminPageControls
{
    [PresenterBinding(typeof(APWorkerDetailsPresenter))]
    public partial class APWorkerDetails : MvpUserControl<APWorkerDetailsControlViewModel>, IAPWorkerDetailsControlView
    {
        public event EventHandler<StringEventArgs> GetWorkerDetailsById;
        public event EventHandler<WorkerDetailsEventArgs> EditRequest;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetWorkersFireEvent(StringEventArgs args)
        {
            this.GetWorkerDetailsById?.Invoke(this, args);
        }

        protected void OnEdit(object sender, EventArgs e)
        {
            var args = new WorkerDetailsEventArgs(this.Id.Value,
                                                  this.FirstName.Value,
                                                  this.LastName.Value,
                                                  this.Gender.Value,
                                                  this.Age.Value,
                                                  this.Rating.Value,
                                                  this.Email.Value,
                                                  this.PhoneNumber.Value,
                                                  this.Country.Value,
                                                  this.City.Value,
                                                  this.Address.Value);

            this.EditRequest?.Invoke(this, args);
        }
    }
}