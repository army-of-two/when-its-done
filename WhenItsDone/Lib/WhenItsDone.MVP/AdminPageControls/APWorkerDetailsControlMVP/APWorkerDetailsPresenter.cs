using Bytes2you.Validation;
using System;
using WebFormsMvp;
using WhenItsDone.Common.Enums;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.MVP.AdminPageControls.EventArguments;
using WhenItsDone.Services.Contracts;
using WhenItsDone.Services.Factories;

namespace WhenItsDone.MVP.AdminPageControls.APWorkerDetailsControlMVP
{
    public class APWorkerDetailsPresenter : Presenter<IAPWorkerDetailsControlView>, IAPWorkerDetailsPresenter
    {
        private readonly IWorkersAsyncService workerService;
        private readonly IWorkerDetailInformationDTOFactory WorkerDetailInformationDTOFactory;

        public APWorkerDetailsPresenter(IAPWorkerDetailsControlView view, IWorkersAsyncService workerService,
                                            IWorkerDetailInformationDTOFactory WorkerDetailInformationDTOFactory)
            : base(view)
        {
            Guard.WhenArgument(workerService, "workerService").IsNull().Throw();
            Guard.WhenArgument(WorkerDetailInformationDTOFactory, "WorkerDetailInformationDTOFactory").IsNull().Throw();

            this.workerService = workerService;
            this.WorkerDetailInformationDTOFactory = WorkerDetailInformationDTOFactory;

            this.View.GetWorkerDetailsById += View_GetWorkerDetailsById;
            this.View.EditRequest += View_EditRequest;
        }

        private void View_EditRequest(object sender, WorkerDetailsEventArgs e)
        {
            var worker = this.WorkerDetailInformationDTOFactory.GetWorkerDetailInformationDTO(e.Id,
                                                                                   e.FirstName,
                                                                                   e.LastName,
                                                                                   e.Gender,
                                                                                   e.Age,
                                                                                   e.Rating,
                                                                                   e.Email,
                                                                                   e.PhoneNumber,
                                                                                   e.Country,
                                                                                   e.City,
                                                                                   e.Street);

            var result = this.workerService.UpdateWorkerDetailInformationDTO(worker);

        }

        private void View_GetWorkerDetailsById(object sender, StringEventArgs e)
        {
            this.View.Model.Worker = this.workerService.GetDetailInfoById(e.StringParameter);
        }

        public WorkerDetailInformationDTO GetMock()
        {
            return new WorkerDetailInformationDTO()
            {
                Id = 1,
                FirstName = "firstName",
                LastName = "lastname",
                Age = 12,
                City = "Stoyo",
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
