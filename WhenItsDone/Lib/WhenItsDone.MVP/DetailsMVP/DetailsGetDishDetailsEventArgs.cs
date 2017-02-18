using System;

namespace WhenItsDone.MVP.DetailsMVP
{
    public class DetailsGetDishDetailsEventArgs : EventArgs
    {
        public DetailsGetDishDetailsEventArgs(string dishId)
        {
            this.DishId = dishId;
        }

        public string DishId { get; private set; }
    }
}
