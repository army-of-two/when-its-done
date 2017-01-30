using System;

namespace WhenItsDone.MVP.ContentContainers.TopDishesMVP
{
    public class TopDishesEventArgs : EventArgs
    {
        public TopDishesEventArgs(int dishesCount, bool addSampleData)
        {
            this.dishesCount = dishesCount;
            this.AddSampleData = addSampleData;
        }

        public int dishesCount { get; set; }

        public bool AddSampleData { get; set; }
    }
}
