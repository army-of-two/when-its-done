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
        private IEnumerable<NamePhotoDishView> sampleNamePhotoDishViewData;

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
            if (this.sampleNamePhotoDishViewData == null)
            {
                this.sampleNamePhotoDishViewData = this.CreateSampleNamePhotoDishViewData();
            }

            return this.sampleNamePhotoDishViewData;
        }

        private IEnumerable<NamePhotoDishView> CreateSampleNamePhotoDishViewData()
        {
            var modelA = new NamePhotoDishView();
            modelA.Name = "Pepperoni";
            modelA.PhotoItemUrl = "https://www.mmfoodmarket.com/images/default-source/products/prepared-meals/pepperoni-pizza.jpg?sfvrsn=2";

            var modelB = new NamePhotoDishView();
            modelB.Name = "Frittata";
            modelB.PhotoItemUrl = "http://assets.epicurious.com/photos/5719486194956b31172ec2d0/master/pass/241324_hires.jpg";

            var modelC = new NamePhotoDishView();
            modelC.Name = "Steak";
            modelC.PhotoItemUrl = "http://www.omahasteaks.com/gifs/990x594/z_fi001.jpg";

            return new NamePhotoDishView[] { modelA, modelB, modelC };
        }
    }
}
