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
        private IList<NamePhotoRatingDishViewDTO> sampleNamePhotoDishViewData;

        public DishesAsyncRepository(IWhenItsDoneDbContext dbContext)
            : base(dbContext)
        {
        }

        public Task<ICollection<NamePhotoRatingDishViewDTO>> GetTopCountDishesByRating(int dishesCount)
        {
            if (dishesCount < 0)
            {
                throw new ArgumentException("dishesCount parameter must be greater than or equal to 0.");
            }

            var task = Task.Run<ICollection<NamePhotoRatingDishViewDTO>>(() =>
            {
                try
                {
                    return this.DbSet.Where(dish => dish.IsDeleted == false).OrderByDescending(dish => dish.Rating).Take(dishesCount).ProjectToList<NamePhotoRatingDishViewDTO>();
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

        public ICollection<NamePhotoRatingDishViewDTO> AddTopCountDishesSampleData(int dishesCount, ICollection<NamePhotoRatingDishViewDTO> existingData)
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

        private IList<NamePhotoRatingDishViewDTO> GetSampleDataOnFailedDBConnection()
        {
            if (this.sampleNamePhotoDishViewData == null)
            {
                this.sampleNamePhotoDishViewData = this.CreateSampleNamePhotoDishViewData();
            }

            return this.sampleNamePhotoDishViewData;
        }

        private IList<NamePhotoRatingDishViewDTO> CreateSampleNamePhotoDishViewData()
        {
            var modelA = new NamePhotoRatingDishViewDTO();
            modelA.Name = "Pepperoni";
            modelA.PhotoItemUrl = "https://www.mmfoodmarket.com/images/default-source/products/prepared-meals/pepperoni-pizza.jpg?sfvrsn=2";
            modelA.Rating = 42;

            var modelB = new NamePhotoRatingDishViewDTO();
            modelB.Name = "Frittata";
            modelB.PhotoItemUrl = "http://assets.epicurious.com/photos/5719486194956b31172ec2d0/master/pass/241324_hires.jpg";
            modelB.Rating = 33;

            var modelC = new NamePhotoRatingDishViewDTO();
            modelC.Name = "Steak";
            modelC.PhotoItemUrl = "http://www.omahasteaks.com/gifs/990x594/z_fi001.jpg";
            modelC.Rating = 96;

            return new NamePhotoRatingDishViewDTO[] { modelA, modelB, modelC };
        }
    }
}
