using System.Collections.Generic;
using System.Linq;

using WhenItsDone.DTOs.DishViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IDishesAsyncService : IGenericAsyncService<Dish>
    {
        int ChangeDishRating(int dishId, int ratingChange);

        DishDetailsViewDTO GetDishDetailsViewById(int? id);

        IEnumerable<NamePhotoRatingDishViewDTO> GetTopCountDishesByRating(int dishesCount, bool addSampleData);

        IQueryable<DishBrowseViewDTO> GetAllDishesQueryable();

        bool CreateDish(string username, string dishName, string description, string price, string calories, string carbohydrates, string fats, string protein, string videoYouTubeUrl, string photoUrl);
    }
}
