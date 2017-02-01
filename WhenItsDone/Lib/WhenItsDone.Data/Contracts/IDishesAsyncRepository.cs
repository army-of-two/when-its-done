using System.Collections.Generic;
using System.Threading.Tasks;

using WhenItsDone.DTOs.DishViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Contracts
{
    public interface IDishesAsyncRepository : IAsyncRepository<Dish>
    {
        Task<ICollection<NamePhotoDishViewDTO>> GetTopCountDishesByRating(int dishesCount);

        ICollection<NamePhotoDishViewDTO> AddTopCountDishesSampleData(int dishesCount, ICollection<NamePhotoDishViewDTO> existingData);
    }
}
