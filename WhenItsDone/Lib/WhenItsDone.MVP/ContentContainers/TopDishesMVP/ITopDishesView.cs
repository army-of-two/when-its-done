using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.ContentContainers.TopDishesMVP
{
    public interface ITopDishesView : IView<TopDishesViewModel>
    {
        event EventHandler<TopDishesEventArgs> GetTopDishes;
    }
}
