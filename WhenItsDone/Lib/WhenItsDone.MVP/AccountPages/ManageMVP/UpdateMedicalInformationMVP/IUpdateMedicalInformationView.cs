using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UpdateMedicalInformationMVP
{
    public interface IUpdateMedicalInformationView : IView<UpdateMedicalInformationViewModel>
    {
        event EventHandler<UpdateMedicalInformationInitialStateEventArgs> InitialState;

        event EventHandler<UpdateMedicalInformationUpdateValuesEventArgs> UpdateValues;
    }
}
