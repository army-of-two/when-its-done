using System;

namespace WhenItsDone.MVP.DetailsMVP
{
    public class DetailsGetDishDetailsEventArgs : EventArgs
    {
        public DetailsGetDishDetailsEventArgs(int? dishId)
        {
            this.DishId = dishId;
        }

        public int? DishId { get; private set; }
    }
}
