using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using WhenItsDone.MVP.AccountPages.ManageMVP.UpdateContactInformationMVP;
using WhenItsDone.WebFormsClient.ViewControls.Contracts;

namespace WhenItsDone.WebFormsClient.ViewControls.ManageUserControls
{
    [PresenterBinding(typeof(IUpdateContactInformationPresenter))]
    public partial class UpdateContactInformationUserControl : MvpUserControl<UpdateContactInformationViewModel>, IUpdateContactInformationView, IShouldLoad
    {
        public event EventHandler<UpdateContactInformationInitialStateEventArgs> UpdateContactInformationInitialState;
        public event EventHandler<UpdateContactInformationUpdateValuesEventArgs> UpdateContactInformationUpdateValues;

        public bool ShouldLoad { get; set; }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (this.ShouldLoad)
            {
                var loggedUserUsername = this.Page.User.Identity.Name;

                var updateContactInformationInitialStateEventArgs = new UpdateContactInformationInitialStateEventArgs(loggedUserUsername);
                this.UpdateContactInformationInitialState?.Invoke(null, updateContactInformationInitialStateEventArgs);
            }
        }

        public void OnUpdateContactInformation(object sender, EventArgs e)
        {

        }
    }
}