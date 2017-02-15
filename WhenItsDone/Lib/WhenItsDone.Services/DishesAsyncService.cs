using System;
using System.Collections.Generic;

using Bytes2you.Validation;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.DTOs.DishViewsDTOs;
using WhenItsDone.Models;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services
{
    public class DishesAsyncService : GenericAsyncService<Dish>, IDishesAsyncService, IGenericAsyncService<Dish>, IService
    {
        private readonly IDishesAsyncRepository dishesAsyncRepository;
        private readonly IUsersAsyncRepository usersAsyncRepository;

        public DishesAsyncService(IDishesAsyncRepository dishesAsyncRepository, IUsersAsyncRepository usersAsyncRepository, IDisposableUnitOfWorkFactory unitOfWorkFactory)
            : base(dishesAsyncRepository, unitOfWorkFactory)
        {
            Guard.WhenArgument(dishesAsyncRepository, nameof(IDishesAsyncRepository)).IsNull().Throw();
            Guard.WhenArgument(usersAsyncRepository, nameof(IUsersAsyncRepository)).IsNull().Throw();

            this.dishesAsyncRepository = dishesAsyncRepository;
            this.usersAsyncRepository = usersAsyncRepository;
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

        public bool CreateDish()
        {
            return true;
        }
    }
}
