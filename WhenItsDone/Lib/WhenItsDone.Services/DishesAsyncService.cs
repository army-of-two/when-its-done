using System;
using System.Collections.Generic;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.DTOs.DishViews;
using WhenItsDone.Models;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services
{
    public class DishesAsyncService : GenericAsyncService<Dish>, IDishesAsyncService, IGenericAsyncService<Dish>
    {
        private readonly IDishesAsyncRepository dishesAsyncRepository;

        public DishesAsyncService(IDishesAsyncRepository asyncRepository, IDisposableUnitOfWorkFactory unitOfWorkFactory)
            : base(asyncRepository, unitOfWorkFactory)
        {
            if (asyncRepository == null)
            {
                throw new ArgumentNullException(nameof(asyncRepository));
            }

            this.dishesAsyncRepository = asyncRepository;
        }

        public IEnumerable<NamePhotoDishView> GetTopCountDishesByRating(int dishesCount)
        {
            if (dishesCount < 0)
            {
                throw new ArgumentException("dishesCount parameter must be greater than or equal to 0.");
            }

            return this.dishesAsyncRepository.GetTopCountDishesByRating(dishesCount).Result;
        }
    }
}
