using System;

using WebFormsMvp;

using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.ContentContainers.TopDishesMVP
{
    public class TopDishesPresenter : Presenter<ITopDishesView>, ITopDishesPresenter
    {
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
            if (args.dishesCount < 0)
            {
                throw new ArgumentException("dishesCount parameter must be greater than or equal to 0.");
            }

            this.View.Model.TopDishes = this.dishesService.GetTopCountDishesByRating(args.dishesCount, args.AddSampleData);
        }
    }
}
