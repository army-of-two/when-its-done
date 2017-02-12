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
            Guard.WhenArgument(args, nameof(UpdateContactInformationInitialStateEventArgs)).IsNull().Throw();
            Guard.WhenArgument(args.LoggedUserUsername, nameof(args.LoggedUserUsername)).IsNullOrEmpty().Throw();

            var foundUserContactInformation = this.usersService.GetCurrentUserContactInformation(args.LoggedUserUsername);

            this.View.Model.Country = foundUserContactInformation.Country ?? "Country not set";
            this.View.Model.City = foundUserContactInformation.City ?? "City not set";
            this.View.Model.Street = foundUserContactInformation.Street ?? "Street not set";
        }

        public void OnUpdateContactInformationUpdateValues(object sender, UpdateContactInformationUpdateValuesEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
