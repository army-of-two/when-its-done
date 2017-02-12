using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UpdateContactInformationMVP
{
    public class UpdateContactInformationPresenter : Presenter<IUpdateContactInformationView>, IUpdateContactInformationPresenter
    {
        public UpdateContactInformationPresenter(IUpdateContactInformationView view)
            : base(view)
        {
            this.View.UpdateContactInformationInitialState += this.OnUpdateContactInformationInitialState;
            this.View.UpdateContactInformationUpdateValues += this.OnUpdateContactInformationUpdateValues;
        }

        public void OnUpdateContactInformationInitialState(object sender, UpdateContactInformationInitialStateEventArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnUpdateContactInformationUpdateValues(object sender, UpdateContactInformationUpdateValuesEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
