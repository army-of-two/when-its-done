using System;
using System.Collections.Generic;

using Bytes2you.Validation;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.DTOs.DishViewsDTOs;
using WhenItsDone.Models;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;
using WhenItsDone.Models.Factories;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Services
{
    public class DishesAsyncService : GenericAsyncService<Dish>, IDishesAsyncService, IGenericAsyncService<Dish>, IService
    {
        private readonly IDishesAsyncRepository dishesAsyncRepository;
        private readonly IUsersAsyncRepository usersAsyncRepository;
        private readonly IInitializedDishFactory dishFactory;
        private readonly IInitializedVideoItemFactory videoItemFactory;
        private readonly IInitializedPhotoItemFactory photoItemFactory;

        public DishesAsyncService(IDishesAsyncRepository dishesAsyncRepository, IUsersAsyncRepository usersAsyncRepository, IInitializedDishFactory dishFactory, IInitializedVideoItemFactory videoItemFactory, IInitializedPhotoItemFactory photoItemFactory, IDisposableUnitOfWorkFactory unitOfWorkFactory)
            : base(dishesAsyncRepository, unitOfWorkFactory)
        {
            Guard.WhenArgument(dishesAsyncRepository, nameof(IDishesAsyncRepository)).IsNull().Throw();
            Guard.WhenArgument(usersAsyncRepository, nameof(IUsersAsyncRepository)).IsNull().Throw();
            Guard.WhenArgument(dishFactory, nameof(IDishFactory)).IsNull().Throw();
            Guard.WhenArgument(videoItemFactory, nameof(IVideoItemFactory)).IsNull().Throw();
            Guard.WhenArgument(photoItemFactory, nameof(IPhotoItemFactory)).IsNull().Throw();

            this.dishesAsyncRepository = dishesAsyncRepository;
            this.usersAsyncRepository = usersAsyncRepository;
            this.dishFactory = dishFactory;
            this.videoItemFactory = videoItemFactory;
            this.photoItemFactory = photoItemFactory;
        }

        public int ChangeDishRating(int dishId, int ratingChange)
        {
            var foundDish = this.dishesAsyncRepository.GetByIdAsync(dishId).Result;
            if (foundDish == null)
            {
                throw new ArgumentException("Dish with this id could not be found.");
            }

            foundDish.Rating += ratingChange;
            if (foundDish.Rating > ValidationConstants.RatingMaxValue)
            {
                foundDish.Rating = ValidationConstants.RatingMaxValue;
            }
            else if (foundDish.Rating < ValidationConstants.RatingMinValue)
            {
                foundDish.Rating = ValidationConstants.RatingMinValue;
            }

            this.dishesAsyncRepository.Update(foundDish);
            using (var unitOfWork = base.UnitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.SaveChangesAsync();
            }

            return foundDish.Rating;
        }

        public DishDetailsViewDTO GetDishDetailsViewById(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            return this.dishesAsyncRepository.GetDishDetailsViewById(id.Value);
        }

        public IEnumerable<NamePhotoRatingDishViewDTO> GetTopCountDishesByRating(int dishesCount, bool addSampleData)
        {
            if (dishesCount < 0)
            {
                throw new ArgumentException("dishesCount parameter must be greater than or equal to 0.");
            }

            var topDishes = this.dishesAsyncRepository.GetTopCountDishesByRating(dishesCount).Result;
            if (topDishes.Count < dishesCount && addSampleData == true)
            {
                topDishes = this.dishesAsyncRepository.AddTopCountDishesSampleData(dishesCount, topDishes);
            }

            return topDishes;
        }

        public bool CreateDish(string username, string dishName, string description, string price, string calories, string carbohydrates, string fats, string protein, string videoYouTubeUrl, string photoUrl)
        {
            var isSuccessful = false;
            if (string.IsNullOrEmpty(photoUrl))
            {
                return isSuccessful;
            }

            if (string.IsNullOrEmpty(videoYouTubeUrl))
            {
                return isSuccessful;
            }

            if (string.IsNullOrEmpty(username))
            {
                return isSuccessful;
            }

            var loggedUserId = this.usersAsyncRepository.GetCurrentUserId(username);
            if (!loggedUserId.HasValue)
            {
                return isSuccessful;
            }

            var convertedPrice = this.ConvertStringValueToDecimal(price, nameof(price));
            var convertedCalories = this.ConvertStringValueToDecimal(calories, nameof(calories));
            var convertedCarbohydrates = this.ConvertStringValueToDecimal(carbohydrates, nameof(carbohydrates));
            var convertedFats = this.ConvertStringValueToDecimal(fats, nameof(fats));
            var convertedProtein = this.ConvertStringValueToDecimal(protein, nameof(protein));

            var nextDish = this.dishFactory.GetInitializedDish(dishName, description, convertedPrice, convertedCalories, convertedCarbohydrates, convertedFats, convertedProtein);
            var nextVideoItem = this.videoItemFactory.GetInitializedVideoItem(dishName, videoYouTubeUrl);
            var nextPhotoItem = this.photoItemFactory.GetInitializedPhotoItem(photoUrl, loggedUserId.Value);

            nextDish.WorkerId = loggedUserId.Value;
            nextDish.VideoItems.Add(nextVideoItem);
            nextDish.PhotoItems.Add(nextPhotoItem);

            this.dishesAsyncRepository.Add(nextDish);
            using (var unitOfWork = base.UnitOfWorkFactory.CreateUnitOfWork())
            {
                var result = unitOfWork.SaveChanges();
                if (result != 0)
                {
                    isSuccessful = true;
                }
            }

            return isSuccessful;
        }

        private decimal ConvertStringValueToDecimal(string value, string parameterName)
        {
            decimal convertedValue;
            if (!decimal.TryParse(value, out convertedValue))
            {
                throw new ArgumentException(parameterName);
            }

            return convertedValue;
        }
    }
}
