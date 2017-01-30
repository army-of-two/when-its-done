using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services
{
    public class DishesDataService : GenericAsyncService<Dish>, IDishesDataService, IGenericAsyncService<Dish>
    {
        public DishesDataService(IAsyncRepository<Dish> asyncRepository, IDisposableUnitOfWorkFactory unitOfWorkFactory)
            : base(asyncRepository, unitOfWorkFactory)
        {
        }
    }
}
