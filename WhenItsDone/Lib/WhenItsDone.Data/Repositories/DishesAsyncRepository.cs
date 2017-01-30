using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
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
                try
                {
                    return this.DbSet.OrderByDescending(dish => dish.Rating).Take(dishesCount).ProjectToList<NamePhotoDishView>();
                }
                catch (EntityException)
                {
                    return this.GetSampleDataOnFailedDBConnection();
                }
                catch (DataException)
                {
                    return this.GetSampleDataOnFailedDBConnection();
                }

            });

            return task;
        }

        private IEnumerable<NamePhotoDishView> GetSampleDataOnFailedDBConnection()
        {
            return new NamePhotoDishView[] { };
        }
    }
}
