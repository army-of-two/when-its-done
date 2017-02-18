using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WhenItsDone.DTOs.DishViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Contracts
{
    public interface IDishesAsyncRepository : IAsyncRepository<Dish>
    {
        DishDetailsViewDTO GetDishDetailsViewById(int id);

        Task<ICollection<NamePhotoRatingDishViewDTO>> GetTopCountDishesByRating(int dishesCount);

        ICollection<NamePhotoRatingDishViewDTO> AddTopCountDishesSampleData(int dishesCount, ICollection<NamePhotoRatingDishViewDTO> existingData);

        IQueryable<DishBrowseViewDTO> GetAllDishesQueryable();
    }
}
