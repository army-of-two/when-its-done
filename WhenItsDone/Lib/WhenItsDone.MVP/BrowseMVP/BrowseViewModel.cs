using System.Linq;

using WhenItsDone.Models;

namespace WhenItsDone.MVP.BrowseMVP
{
    public class BrowseViewModel
    {
        public IQueryable<Dish> BrowseDishesViews { get; set; }
    }
}
