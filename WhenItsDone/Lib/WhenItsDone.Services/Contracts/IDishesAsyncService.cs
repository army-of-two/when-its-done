using System.Collections.Generic;

using WhenItsDone.DTOs.DishViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Services.Contracts
{
    public interface IDishesAsyncService : IGenericAsyncService<Dish>
    {
        DishDetailsViewDTO GetDishDetailsViewById(int id);

        IEnumerable<NamePhotoRatingDishViewDTO> GetTopCountDishesByRating(int dishesCount, bool addSampleData);

        bool CreateDish(string username, string dishName, string description, string price, string calories, string carbohydrates, string fats, string protein, string videoYouTubeUrl, string photoUrl);
    }
}
