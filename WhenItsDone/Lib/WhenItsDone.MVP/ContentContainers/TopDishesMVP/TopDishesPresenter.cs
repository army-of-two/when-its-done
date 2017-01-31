using System;

using WebFormsMvp;

using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.ContentContainers.TopDishesMVP
{
    public class TopDishesPresenter : Presenter<ITopDishesView>, ITopDishesPresenter
    {
        private readonly ITopDishesView view;
        private readonly IDishesAsyncService dishesService;

        public TopDishesPresenter(ITopDishesView view, IDishesAsyncService dishesService)
            : base(view)
        {
            if (dishesService == null)
            {
                throw new ArgumentNullException(nameof(dishesService));
            }

            this.dishesService = dishesService;

            this.View.GetTopDishes += this.OnGetTopDishes;
        }

        public void OnGetTopDishes(object sender, TopDishesEventArgs args)
        {
            this.view.Model.TopDishes = this.dishesService.GetTopCountDishesByRating(args.dishesCount, args.AddSampleData);
        }
    }
}
