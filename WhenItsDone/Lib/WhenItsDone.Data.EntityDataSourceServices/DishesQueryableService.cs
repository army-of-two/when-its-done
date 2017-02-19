using System.Data.Entity;
using System.Linq;

using Bytes2you.Validation;

using WhenItsDone.Data.EntityDataSourceContainer;

namespace WhenItsDone.Data.EntityDataSourceServices
{
    public class DishesQueryableService : IDishesQueryableService
    {
        private readonly DbSet<Dishes> dishes;

        public DishesQueryableService(IEntities dbContext)
        {
            Guard.WhenArgument(dbContext, nameof(IEntities)).IsNull().Throw();

            this.dishes = dbContext.Dishes;
        }

        public IQueryable<Dishes> GetAllDishesQueryable()
        {
            return this.dishes;
        }
    }
}
