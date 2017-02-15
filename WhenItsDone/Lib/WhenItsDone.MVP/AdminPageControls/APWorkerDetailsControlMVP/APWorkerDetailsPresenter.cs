using System;
using WebFormsMvp;
using WhenItsDone.MVP.AdminPageControls.APWorkersControlMVP;

namespace WhenItsDone.MVP.AdminPageControls.APWorkerDetailsControlMVP
{
    public class APWorkerDetailsPresenter : Presenter<IAPWorkerDetailsControlView>, IAPWorkerDetailsPresenter
    {
        public APWorkerDetailsPresenter(IAPWorkerDetailsControlView view)
            : base(view)
        {
            this.View.GetWorkerDetailsById += View_GetWorkerDetailsById;
        }

        private void View_GetWorkerDetailsById(object sender, string e)
        {
            throw new NotImplementedException();
        }
    }
}
