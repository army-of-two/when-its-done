using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using WhenItsDone.MVP.AccountPages.ManageMVP.UpdateMedicalInformationMVP;

namespace WhenItsDone.WebFormsClient.ViewControls.ManageUserControls
{
    [PresenterBinding(typeof(IUpdateMedicalInformationPresenter))]
    public partial class UpdateMedicalInformationUserControl : MvpUserControl<UpdateMedicalInformationViewModel>, IUpdateMedicalInformationView
    {
        public event EventHandler<UpdateMedicalInformationInitialStateEventArgs> InitialState;
        public event EventHandler<UpdateMedicalInformationUpdateValuesEventArgs> UpdateValues;

        protected void Page_Load(object sender, EventArgs e)
        {
            var loggedUserUsername = this.Page.User.Identity.Name;

            var updateMedicalInformationInitialStateEventArgs = new UpdateMedicalInformationInitialStateEventArgs(loggedUserUsername);
            this.InitialState?.Invoke(null, updateMedicalInformationInitialStateEventArgs);
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