using System;

namespace WhenItsDone.MVP.ContentContainers.TopDishesMVP
{
    public class TopDishesEventArgs : EventArgs
    {
        public TopDishesEventArgs(int dishesCount)
        {
            this.dishesCount = dishesCount;
        }

        public int dishesCount { get; set; }
    }
}
