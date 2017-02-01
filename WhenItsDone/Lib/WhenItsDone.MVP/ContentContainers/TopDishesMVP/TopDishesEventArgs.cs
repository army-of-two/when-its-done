using System;

namespace WhenItsDone.MVP.ContentContainers.TopDishesMVP
{
    public class TopDishesEventArgs : EventArgs
    {
        public TopDishesEventArgs(int dishesCount, bool addSampleData)
        {
            this.DishesCount = dishesCount;
            this.AddSampleData = addSampleData;
        }

        public int DishesCount { get; private set; }

        public bool AddSampleData { get; private set; }
    }
}
