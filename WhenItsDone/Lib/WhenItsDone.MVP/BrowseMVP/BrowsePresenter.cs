using System;

using Bytes2you.Validation;

using WebFormsMvp;

using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.BrowseMVP
{
    public class BrowsePresenter : Presenter<IBrowseView>, IBrowsePresenter
    {
        private readonly IDishesAsyncService dishesAsyncService;

        public BrowsePresenter(IBrowseView view, IDishesAsyncService dishesAsyncService)
            : base(view)
        {
            Guard.WhenArgument(dishesAsyncService, nameof(IDishesAsyncService)).IsNull().Throw();

            this.dishesAsyncService = dishesAsyncService;

            base.View.OnBrowseDishesGetData += this.OnBrowseDishesGetData;
        }

        private void OnBrowseDishesGetData(object sender, EventArgs e)
        {
            base.View.Model.BrowseDishesViews = this.dishesAsyncService.GetAllDishesQueryable();
        }
    }
}
