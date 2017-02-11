using System;

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

            this.View.Model.HeightInCm = foundUserMedicalInformation?.HeightInCm.ToString();
            this.View.Model.WeightInKg = foundUserMedicalInformation?.WeightInKg.ToString();
        }

        public void OnUpdateValues(object sender, UpdateMedicalInformationUpdateValuesEventArgs args)
        {
            Guard.WhenArgument(args, nameof(UpdateMedicalInformationUpdateValuesEventArgs)).IsNull().Throw();
            Guard.WhenArgument(args.LoggedUserUsername, nameof(args.LoggedUserUsername)).IsNullOrEmpty().Throw();

            try
            {
                var updatedUser = this.usersService.UpdateUserMedicalInformationFromUserInput(args.LoggedUserUsername, args.HeightInCm, args.WeightInKg);
                if (updatedUser == null)
                {
                    throw new ArgumentException("User could not be found.");
                }
                else
                {
                    this.View.Model.HeightInCm = updatedUser.MedicalInformation.HeightInCm?.ToString() ?? "Update information";
                    this.View.Model.WeightInKg = updatedUser.MedicalInformation.WeightInKg?.ToString() ?? "Update information";
                }
            }
            catch (Exception)
            {
                this.View.Model.HeightInCm = "Update information";
                this.View.Model.WeightInKg = "Update information";
            }
        }
    }
}
