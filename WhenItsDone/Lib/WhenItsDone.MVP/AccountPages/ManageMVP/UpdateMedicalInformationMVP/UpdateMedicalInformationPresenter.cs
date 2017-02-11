using WebFormsMvp;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UpdateMedicalInformationMVP
{
    public class UpdateMedicalInformationPresenter : Presenter<IUpdateMedicalInformationView>, IUpdateMedicalInformationPresenter
    {
        public UpdateMedicalInformationPresenter(IUpdateMedicalInformationView view)
            : base(view)
        {
            this.View.InitialState += this.OnInitialState;
            this.View.UpdateValues += this.OnUpdateValues;
        }

        public void OnInitialState(object sender, UpdateMedicalInformationInitialStateEventArgs args)
        {

        }

        public void OnUpdateValues(object sender, UpdateMedicalInformationUpdateValuesEventArgs args)
        {

        }
    }
}
