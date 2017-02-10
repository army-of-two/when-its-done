using System;
using System.Collections.Generic;
using WebFormsMvp;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.AdminPageControls.APWorkersControlMVP
{
    public class APWorkersControlPresenter : Presenter<IAPWorkersControlView>, IAPWorkersControlPresenter
    {
        private readonly IWorkersAsyncService workersService;

        public APWorkersControlPresenter(IAPWorkersControlView view, IWorkersAsyncService workersService)
            : base(view)
        {
            if (workersService == null)
            {
                throw new ArgumentNullException("WorkersService");
            }

            this.workersService = workersService;

            this.View.GetWorkersNamesAndId += View_GetWorkersNamesAndId;
        }

        private void View_GetWorkersNamesAndId(object sender, EventArgs e)
        {
            this.View.Model.WorkersWithDishes = this.GetMocks();// this.workersService.GetWorkersNamesAndId();
        }

        private IEnumerable<WorkerNamesIdDTO> GetMocks()
        {
            return new List<WorkerNamesIdDTO>()
            {
                new WorkerNamesIdDTO()
                {
                    Id=1,
                    FirstName="first",
                    LastName="first2"
                }
                ,
                new WorkerNamesIdDTO()
                {
                    Id=2,
                    FirstName="second",
                    LastName="second2"
                }
                ,new WorkerNamesIdDTO()
                {
                    Id=3,
                    FirstName="third",
                    LastName="third2"
                }
                ,new WorkerNamesIdDTO()
                {
                    Id=4,
                    FirstName="fourth",
                    LastName="fourth2"
                }
                ,new WorkerNamesIdDTO()
                {
                    Id=5,
                    FirstName="fifth",
                    LastName="fifth2"
                }
            };
        }
    }
}
