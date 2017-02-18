using System.Linq;

using WhenItsDone.DTOs.DishViewsDTOs;

namespace WhenItsDone.MVP.BrowseMVP
{
    public class BrowseViewModel
    {
        public IQueryable<DishBrowseViewDTO> BrowseDishesViews { get; set; }
    }
}
