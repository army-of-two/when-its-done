using System.Linq;

using WhenItsDone.Data.EntityDataSourceContainer;

namespace WhenItsDone.Data.EntityDataSourceServices
{
    public interface IDishesQueryableService
    {
        IQueryable<Dishes> GetAllDishesQueryable();
    }
}
