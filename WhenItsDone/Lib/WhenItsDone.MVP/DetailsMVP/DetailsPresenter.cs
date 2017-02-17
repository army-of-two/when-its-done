using Bytes2you.Validation;

using WebFormsMvp;

using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.DetailsMVP
{
    public class DetailsPresenter : Presenter<IDetailsView>, IDetailsPresenter
    {
        private readonly IDishesAsyncService dishesAsyncService;

        public DetailsPresenter(IDetailsView view, IDishesAsyncService dishesAsyncService)
            : base(view)
        {
            Guard.WhenArgument(dishesAsyncService, nameof(IDishesAsyncService)).IsNull().Throw();

            this.dishesAsyncService = dishesAsyncService;

            base.View.OnGetDishDetails += this.OnGetDishDetails;
        }

        private void OnGetDishDetails(object sender, DetailsGetDishDetailsEventArgs args)
        {
            Guard.WhenArgument(args, nameof(DetailsGetDishDetailsEventArgs)).IsNull().Throw();
        }
    }
}
