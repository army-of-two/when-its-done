using WebFormsMvp;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UpdateMedicalInformationMVP
{
    public class UpdateMedicalInformationInitialPresenter : Presenter<IUpdateMedicalInformationView>, IUpdateMedicalInformationInitialPresenter
    {
        public UpdateMedicalInformationInitialPresenter(IUpdateMedicalInformationView view)
            : base(view)
        {
        }
    }
}
