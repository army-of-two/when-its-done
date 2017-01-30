using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

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

        public Task<IEnumerable<NamePhotoDishView>> GetTopCountDishesByRating(int dishesCount)
        {
            var task = Task.Run<IEnumerable<NamePhotoDishView>>(() =>
            {
                return this.DbSet.OrderByDescending(dish => dish.Rating).Take(dishesCount).ProjectToList<NamePhotoDishView>();
            });

            return task;
        }
    }
}
