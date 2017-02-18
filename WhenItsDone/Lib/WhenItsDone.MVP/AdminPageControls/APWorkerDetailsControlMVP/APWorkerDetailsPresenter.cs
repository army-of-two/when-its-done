using System;
using WebFormsMvp;
using WhenItsDone.Common.Enums;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.MVP.AdminPageControls.EventArguments;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.AdminPageControls.APWorkerDetailsControlMVP
{
    public class APWorkerDetailsPresenter : Presenter<IAPWorkerDetailsControlView>, IAPWorkerDetailsPresenter
    {
        private readonly IWorkersAsyncService workerService;

        public APWorkerDetailsPresenter(IAPWorkerDetailsControlView view, IWorkersAsyncService workerService)
            : base(view)
        {
            if (workerService == null)
            {
                throw new ArgumentNullException(nameof(workerService));
            }

            this.workerService = workerService;

            this.View.GetWorkerDetailsById += View_GetWorkerDetailsById;
        }

        private void View_GetWorkerDetailsById(object sender, StringEventArgs e)
        {
            this.View.Model.Worker = this.GetMock(); // this.workerService.GetDetailInfoById(e.StringParameter);
        }

        public WorkerDetailInformationDTO GetMock()
        {
            return new WorkerDetailInformationDTO()
            {
                Id = 1,
                FirstName = "firstName",
                LastName = "lastname",
                Age = 12,
                AddressInformationId = 1,
                City = "Stoyo",
                ContactInformationId = 18,
                Country = "Brazil",
                Email = "me@me.me",
                Gender = GenderType.Female,
                PhoneNumber = "call me",
                Rating = 4,
                Street = "Na kraq"
            };
        }
    }
}
