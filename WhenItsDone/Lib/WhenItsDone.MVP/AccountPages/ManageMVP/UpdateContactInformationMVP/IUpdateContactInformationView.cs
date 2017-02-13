using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UpdateContactInformationMVP
{
    public interface IUpdateContactInformationView : IView<UpdateContactInformationViewModel>
    {
        event EventHandler<UpdateContactInformationInitialStateEventArgs> UpdateContactInformationInitialState;

        event EventHandler<UpdateContactInformationUpdateValuesEventArgs> UpdateContactInformationUpdateValues;
    }
}
