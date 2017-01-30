using System;
using System.Collections.Generic;
using WhenItsDone.Data.Contracts;
using WhenItsDone.DTOs.DishViews;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Repositories
{
    public class DishesAsyncRepository : GenericAsyncRepository<Dish>, IAsyncRepository<Dish>, IDishesAsyncRepository
    {
        public DishesAsyncRepository(IWhenItsDoneDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<NamePhotoDishView> GetTopThreeDishesByRating()
        {


            throw new NotImplementedException();
        }
    }
}
