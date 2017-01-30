using System.Collections.Generic;

using WhenItsDone.DTOs.DishViews;

namespace WhenItsDone.MVP.ContentContainers.TopDishesMVP
{
    public class TopDishesViewModel
    {
        public IEnumerable<NamePhotoDishView> TopDishes { get; set; }
    }
}
