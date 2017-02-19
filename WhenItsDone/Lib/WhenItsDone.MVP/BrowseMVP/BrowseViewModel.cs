using System.Linq;

using WhenItsDone.Data.EntityDataSourceContainer;

namespace WhenItsDone.MVP.BrowseMVP
{
    public class BrowseViewModel
    {
        public IQueryable<Dishes> BrowseDishesViews { get; set; }
    }
}
