using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using WhenItsDone.MVP.AccountPages.ManageMVP.UpdateMedicalInformationMVP;
using WhenItsDone.WebFormsClient.ViewControls.Contracts;

namespace WhenItsDone.WebFormsClient.ViewControls.ManageUserControls
{
    [PresenterBinding(typeof(IUpdateMedicalInformationPresenter))]
    public partial class UpdateMedicalInformationUserControl : MvpUserControl<UpdateMedicalInformationViewModel>, IUpdateMedicalInformationView, IShouldLoad
    {
        public event EventHandler<UpdateMedicalInformationInitialStateEventArgs> InitialState;
        public event EventHandler<UpdateMedicalInformationUpdateValuesEventArgs> UpdateValues;

        public bool ShouldLoad { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var loggedUserUsername = this.Page.User.Identity.Name;

            if (this.ShouldLoad)
            {
                var updateMedicalInformationInitialStateEventArgs = new UpdateMedicalInformationInitialStateEventArgs(loggedUserUsername);
                this.InitialState?.Invoke(null, updateMedicalInformationInitialStateEventArgs);
            }
        }

        public void OnUpdateMedicalInformation(object sender, EventArgs e)
        {
            var loggedUserUsername = this.Page.User.Identity.Name;
            var heightInCm = this.HeightInCmTextBox.Text;
            var weightInKg = this.WeightInKgTextBox.Text;

            var updateMedicalInformationUpdateValuesEventArgs = new UpdateMedicalInformationUpdateValuesEventArgs(loggedUserUsername, heightInCm, weightInKg);
            this.UpdateValues?.Invoke(null, updateMedicalInformationUpdateValuesEventArgs);
        }
    }
}