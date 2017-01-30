using System.Collections.Generic;

using WhenItsDone.DTOs.DishViews;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Contracts
{
    public interface IDishesAsyncRepository : IAsyncRepository<Dish>
    {
        IEnumerable<NamePhotoDishView> GetTopThreeDishesByRating();
    }
}
