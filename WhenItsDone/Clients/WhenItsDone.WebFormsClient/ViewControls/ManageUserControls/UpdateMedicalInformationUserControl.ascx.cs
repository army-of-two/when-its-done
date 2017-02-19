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
        public event EventHandler<UpdateMedicalInformationInitialStateEventArgs> UpdateMedicalInformationInitialState;
        public event EventHandler<UpdateMedicalInformationUpdateValuesEventArgs> UpdateMedicalInformationUpdateValues;

        public bool ShouldLoad { get; set; }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (this.ShouldLoad)
            {
                var loggedUserUsername = this.Page.User.Identity.Name;

                var updateMedicalInformationInitialStateEventArgs = new UpdateMedicalInformationInitialStateEventArgs(loggedUserUsername);
                this.UpdateMedicalInformationInitialState?.Invoke(null, updateMedicalInformationInitialStateEventArgs);
            }
        }

        public void OnUpdateMedicalInformation(object sender, EventArgs e)
        {
            var loggedUserUsername = this.Page.User.Identity.Name;
            var heightInCm = this.HeightInCmTextBox.Value;
            var weightInKg = this.WeightInKgTextBox.Value;

            var updateMedicalInformationUpdateValuesEventArgs = new UpdateMedicalInformationUpdateValuesEventArgs(loggedUserUsername, heightInCm, weightInKg);
            this.UpdateMedicalInformationUpdateValues?.Invoke(null, updateMedicalInformationUpdateValuesEventArgs);
        }
    }
}