using System.Collections.Generic;
using System.Threading.Tasks;

using WhenItsDone.DTOs.DishViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Contracts
{
    public interface IDishesAsyncRepository : IAsyncRepository<Dish>
    {
        Task<IEnumerable<NamePhotoDishViewDTO>> GetTopCountDishesByRating(int dishesCount);

        IEnumerable<NamePhotoDishViewDTO> AddTopCountDishesSampleData(IEnumerable<NamePhotoDishViewDTO> existingData);
    }
}
