using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using WhenItsDone.Data.Contracts;
using WhenItsDone.DTOs.DishViewsDTOs;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Repositories
{
    public class DishesAsyncRepository : GenericAsyncRepository<Dish>, IAsyncRepository<Dish>, IDishesAsyncRepository
    {
        private IList<NamePhotoDishViewDTO> sampleNamePhotoDishViewData;

        public DishesAsyncRepository(IWhenItsDoneDbContext dbContext)
            : base(dbContext)
        {
        }

        public Task<ICollection<NamePhotoDishViewDTO>> GetTopCountDishesByRating(int dishesCount)
        {
            if (dishesCount < 0)
            {
                throw new ArgumentException("dishesCount parameter must be greater than or equal to 0.");
            }

            var task = Task.Run<ICollection<NamePhotoDishViewDTO>>(() =>
            {
                try
                {
                    return this.DbSet.Where(dish => dish.IsDeleted == false).OrderByDescending(dish => dish.Rating).Take(dishesCount).ProjectToList<NamePhotoDishViewDTO>();
                }
                catch (EntityException)
                {
                    return this.GetSampleDataOnFailedDBConnection();
                }
                catch (DataException)
                {
                    return this.GetSampleDataOnFailedDBConnection();
                }
                catch (Exception)
                {
                    return this.GetSampleDataOnFailedDBConnection();
                }
            });

            return task;
        }

        public ICollection<NamePhotoDishViewDTO> AddTopCountDishesSampleData(int dishesCount, ICollection<NamePhotoDishViewDTO> existingData)
        {
            var existingDataList = existingData.ToList();
            var sampleData = this.GetSampleDataOnFailedDBConnection();

            var index = 0;
            var sampleDataItemsCount = sampleData.Count;

            while (existingDataList.Count < dishesCount)
            {
                var nextIndex = index++ % sampleDataItemsCount;
                existingDataList.Add(sampleData[nextIndex]);
            }

            return existingDataList;
        }

        private IList<NamePhotoDishViewDTO> GetSampleDataOnFailedDBConnection()
        {
            if (this.sampleNamePhotoDishViewData == null)
            {
                this.sampleNamePhotoDishViewData = this.CreateSampleNamePhotoDishViewData();
            }

            return this.sampleNamePhotoDishViewData;
        }

        private IList<NamePhotoDishViewDTO> CreateSampleNamePhotoDishViewData()
        {
            var modelA = new NamePhotoDishViewDTO();
            modelA.Name = "Pepperoni";
            modelA.PhotoItemUrl = "https://www.mmfoodmarket.com/images/default-source/products/prepared-meals/pepperoni-pizza.jpg?sfvrsn=2";

            var modelB = new NamePhotoDishViewDTO();
            modelB.Name = "Frittata";
            modelB.PhotoItemUrl = "http://assets.epicurious.com/photos/5719486194956b31172ec2d0/master/pass/241324_hires.jpg";

            var modelC = new NamePhotoDishViewDTO();
            modelC.Name = "Steak";
            modelC.PhotoItemUrl = "http://www.omahasteaks.com/gifs/990x594/z_fi001.jpg";

            return new NamePhotoDishViewDTO[] { modelA, modelB, modelC };
        }
    }
}
