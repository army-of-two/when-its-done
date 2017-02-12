using System;

using Bytes2you.Validation;

using WebFormsMvp;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UpdateContactInformationMVP
{
    public class UpdateContactInformationPresenter : Presenter<IUpdateContactInformationView>, IUpdateContactInformationPresenter
    {
        private readonly IUsersAsyncService usersService;

        public UpdateContactInformationPresenter(IUpdateContactInformationView view, IUsersAsyncService usersService)
            : base(view)
        {
            Guard.WhenArgument(usersService, nameof(IUsersAsyncService)).IsNull().Throw();

            this.usersService = usersService;

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
