using System;
using WebFormsMvp;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.AdminPageControls.APWorkerDetailsControlMVP
{
    public class APWorkerDetailsPresenter : Presenter<IAPWorkerDetailsControlView>, IAPWorkerDetailsPresenter
    {
        private readonly IWorkersAsyncService workerService;

        public APWorkerDetailsPresenter(IAPWorkerDetailsControlView view, IWorkersAsyncService workerService)
            : base(view)
        {
            this.workerService = workerService ?? throw new ArgumentNullException(nameof(workerService));

            this.View.GetWorkerDetailsById += View_GetWorkerDetailsById;
        }

        private void View_GetWorkerDetailsById(object sender, string e)
        {
            this.View.Model.Worker = this.workerService.GetDetailInfoById(e);
        }
    }
}
