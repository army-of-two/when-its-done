using System.Collections.Generic;

using WhenItsDone.DTOs.DishViews;
using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IDishesDataService : IGenericAsyncService<Dish>
    {
        IEnumerable<NamePhotoDishView> GetTopThreeDishesByRating();
    }
}
