using System.Collections.Generic;

using WhenItsDone.DTOs.DishViewsDTOs;

namespace WhenItsDone.MVP.ContentContainers.TopDishesMVP
{
    public class TopDishesViewModel
    {
        public IEnumerable<NamePhotoDishViewDTO> TopDishes { get; set; }
    }
}
