using System.Collections.Generic;
using System.Threading.Tasks;

using WhenItsDone.DTOs.DishViews;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Contracts
{
    public interface IDishesAsyncRepository : IAsyncRepository<Dish>
    {
        Task<IEnumerable<NamePhotoDishView>> GetTopCountDishesByRating(int dishesCount);
    }
}
