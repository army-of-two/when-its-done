using System.Collections.Generic;
using System.Threading.Tasks;

using WhenItsDone.DTOs.DishViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Contracts
{
    public interface IDishesAsyncRepository : IAsyncRepository<Dish>
    {
        Task<ICollection<NamePhotoRatingDishViewDTO>> GetTopCountDishesByRating(int dishesCount);

        ICollection<NamePhotoRatingDishViewDTO> AddTopCountDishesSampleData(int dishesCount, ICollection<NamePhotoRatingDishViewDTO> existingData);
    }
}
