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
        private readonly IDisposableUnitOfWorkFactory unitOfWorkFactory;

        public DishesAsyncService(IDishesAsyncRepository asyncRepository, IDisposableUnitOfWorkFactory unitOfWorkFactory)
            : base(asyncRepository, unitOfWorkFactory)
        {
            if (asyncRepository == null)
            {
                throw new ArgumentNullException(nameof(asyncRepository));
            }

            if (unitOfWorkFactory == null)
            {
                throw new ArgumentNullException(nameof(unitOfWorkFactory));
            }

            this.dishesAsyncRepository = asyncRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public IEnumerable<NamePhotoDishView> GetTopCountDishesByRating(int dishesCount)
        {
            return this.dishesAsyncRepository.GetTopCountDishesByRating(dishesCount).Result;
        }
    }
}
