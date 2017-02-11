using Bytes2you.Validation;

using WebFormsMvp;

using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.AccountPages.ManageMVP.UpdateMedicalInformationMVP
{
    public class UpdateMedicalInformationPresenter : Presenter<IUpdateMedicalInformationView>, IUpdateMedicalInformationPresenter
    {
        private readonly IUsersAsyncService usersService;

        public UpdateMedicalInformationPresenter(IUpdateMedicalInformationView view, IUsersAsyncService usersService)
            : base(view)
        {
            Guard.WhenArgument(usersService, nameof(IUsersAsyncService)).IsNull().Throw();

            this.usersService = usersService;

            this.View.InitialState += this.OnInitialState;
            this.View.UpdateValues += this.OnUpdateValues;
        }

        public void OnInitialState(object sender, UpdateMedicalInformationInitialStateEventArgs args)
        {
            Guard.WhenArgument(args, nameof(UpdateMedicalInformationInitialStateEventArgs)).IsNull().Throw();
            Guard.WhenArgument(args.LoggedUserUsername, nameof(args.LoggedUserUsername)).IsNullOrEmpty().Throw();

            var foundUserMedicalInformation = this.usersService.GetCurrentUserMedicalInformation(args.LoggedUserUsername);

            this.View.Model.HeightInCm = foundUserMedicalInformation?.HeightInCm;
            this.View.Model.WeightInKg = foundUserMedicalInformation?.WeightInKg;
        }

        public void OnUpdateValues(object sender, UpdateMedicalInformationUpdateValuesEventArgs args)
        {

        }
    }
}
