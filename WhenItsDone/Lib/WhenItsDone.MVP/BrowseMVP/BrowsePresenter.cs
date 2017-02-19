using System;

using Bytes2you.Validation;

using WebFormsMvp;

using WhenItsDone.Data.EntityDataSourceServices;

namespace WhenItsDone.MVP.BrowseMVP
{
    public class BrowsePresenter : Presenter<IBrowseView>, IBrowsePresenter
    {
        private readonly IDishesQueryableService dishesAsyncService;

        public BrowsePresenter(IBrowseView view, IDishesQueryableService dishesAsyncService)
            : base(view)
        {
            Guard.WhenArgument(dishesAsyncService, nameof(IDishesQueryableService)).IsNull().Throw();

            this.dishesAsyncService = dishesAsyncService;

            base.View.OnBrowseDishesGetData += this.OnBrowseDishesGetData;
        }

        private void OnBrowseDishesGetData(object sender, EventArgs e)
        {
            base.View.Model.BrowseDishesViews = this.dishesAsyncService.GetAllDishesQueryable();
        }
    }
}
