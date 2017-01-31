using System.Collections.Generic;

using WhenItsDone.DTOs.DishViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IDishesAsyncService : IGenericAsyncService<Dish>
    {
        IEnumerable<NamePhotoDishViewDTO> GetTopCountDishesByRating(int dishesCount, bool addSampleData);
    }
}
