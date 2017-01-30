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
    public class DishesDataService : GenericAsyncService<Dish>, IDishesDataService, IGenericAsyncService<Dish>
    {
        private readonly IAsyncRepository<Dish> asyncRepository;
        private readonly IDisposableUnitOfWorkFactory unitOfWorkFactory;

        public DishesDataService(IAsyncRepository<Dish> asyncRepository, IDisposableUnitOfWorkFactory unitOfWorkFactory)
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

            this.asyncRepository = asyncRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public IEnumerable<NamePhotoDishView> GetTopThreeDishesByRating()
        {
           

            throw new NotImplementedException();
        }
    }
}
