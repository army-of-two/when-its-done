using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Repositories;
using WhenItsDone.DTOs.DishViews;
using WhenItsDone.Models;
using AutoMapper;

namespace WhenItsDone.Data.Tests.RepositoriesTests.DishesAsyncRepositoryTests
{
    [TestFixture]
    public class GetTopCountDishesByRating_Should
    {
        [Test]
        public void ShouldThrowArgumentException_WhenDishesCountParameterIsNegative()
        {
            var mockDbSet = new Mock<DbSet<Dish>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<Dish>()).Returns(mockDbSet.Object);

            var asyncDishesRepositoryInstace = new DishesAsyncRepository(mockDbContext.Object);

            var fakeData = new List<Dish>()
            {
               new Mock<Dish>().Object,
               new Mock<Dish>().Object,
               new Mock<Dish>().Object,
               new Mock<Dish>().Object,
               new Mock<Dish>().Object,
               new Mock<Dish>().Object
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<Dish>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<Dish>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<Dish>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<Dish>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var invalidDishesCount = -1;
            Assert.That(
                async () => await asyncDishesRepositoryInstace.GetTopCountDishesByRating(invalidDishesCount),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("dishesCount parameter must be greater than or equal to 0."));
        }

        [Test]
        public void ShouldReturnTaskOfCorrectType_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<Dish>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<Dish>()).Returns(mockDbSet.Object);

            var asyncDishesRepositoryInstace = new DishesAsyncRepository(mockDbContext.Object);

            var fakeData = new List<Dish>()
            {
                new Mock<Dish>().Object,
                new Mock<Dish>().Object,
                new Mock<Dish>().Object,
                new Mock<Dish>().Object
            };
            mockDbSet.As<IDbSet<Dish>>().Setup(mock => mock.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var dishesCount = 3;
            var actualReturnedCollection = asyncDishesRepositoryInstace.GetTopCountDishesByRating(dishesCount);

            Assert.That(actualReturnedCollection.GetType(), Is.EqualTo(typeof(Task<IEnumerable<NamePhotoDishView>>)));
        }

        [Test]
        public void ShouldReturnTaskOfCorrectStatus_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<Dish>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<Dish>()).Returns(mockDbSet.Object);

            var asyncDishesRepositoryInstace = new DishesAsyncRepository(mockDbContext.Object);

            var fakeData = new List<Dish>()
            {
                new Mock<Dish>().Object,
                new Mock<Dish>().Object,
                new Mock<Dish>().Object,
                new Mock<Dish>().Object
            };
            mockDbSet.As<IDbSet<Dish>>().Setup(mock => mock.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var dishesCount = 3;
            var actualReturnedCollection = asyncDishesRepositoryInstace.GetTopCountDishesByRating(dishesCount);

            Assert.That(actualReturnedCollection.Status, Is.EqualTo(TaskStatus.Running).Or.EqualTo(TaskStatus.WaitingToRun).Or.EqualTo(TaskStatus.RanToCompletion));
        }

        [Test]
        public void ShouldReturnCollection_WhichIsSortedInDescendingOrderByRating()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Dish, NamePhotoDishView>()
                    .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Recipe.Name));
            });

            var mockDbSet = new Mock<DbSet<Dish>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<Dish>()).Returns(mockDbSet.Object);

            var asyncDishesRepositoryInstace = new DishesAsyncRepository(mockDbContext.Object);

            var firstDish = new Mock<Dish>();
            var firstDto = new Mock<NamePhotoDishView>();
            firstDish.Object.Rating = 100;
            firstDish.SetupGet(dish => dish.Recipe).Returns(new Mock<Recipe>().Object);
            firstDish.SetupGet(dish => dish.PhotoItems).Returns(new List<PhotoItem>() { new Mock<PhotoItem>().Object });
            firstDish.Object.Recipe.Name = "first";
            firstDto.Object.Name = "first";

            var secondDish = new Mock<Dish>();
            var secondDto = new Mock<NamePhotoDishView>();
            secondDish.Object.Rating = 50;
            secondDish.SetupGet(dish => dish.Recipe).Returns(new Mock<Recipe>().Object);
            secondDish.SetupGet(dish => dish.PhotoItems).Returns(new List<PhotoItem>() { new Mock<PhotoItem>().Object });
            secondDish.Object.Recipe.Name = "second";
            secondDto.Object.Name = "second";

            var thirdDish = new Mock<Dish>();
            var thirdDto = new Mock<NamePhotoDishView>();
            thirdDish.Object.Rating = -33;
            thirdDish.SetupGet(dish => dish.Recipe).Returns(new Mock<Recipe>().Object);
            thirdDish.SetupGet(dish => dish.PhotoItems).Returns(new List<PhotoItem>() { new Mock<PhotoItem>().Object });
            thirdDish.Object.Recipe.Name = "third";
            thirdDto.Object.Name = "third";

            var forthDish = new Mock<Dish>();
            var forthDto = new Mock<NamePhotoDishView>();
            forthDish.Object.Rating = -42;
            forthDish.SetupGet(dish => dish.Recipe).Returns(new Mock<Recipe>().Object);
            forthDish.SetupGet(dish => dish.PhotoItems).Returns(new List<PhotoItem>() { new Mock<PhotoItem>().Object });
            forthDish.Object.Recipe.Name = "forth";
            forthDto.Object.Name = "forth";

            var fakeData = new List<Dish>()
            {
                forthDish.Object,
                firstDish.Object,
                thirdDish.Object,
                secondDish.Object
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<Dish>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<Dish>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<Dish>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<Dish>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var dishesCount = 3;
            var actualReturnedCollection = asyncDishesRepositoryInstace.GetTopCountDishesByRating(dishesCount);

            var expectedResult = new List<NamePhotoDishView>() { firstDto.Object, secondDto.Object, thirdDto.Object };
            var actualResult = actualReturnedCollection.Result;

            var dishesAreSorted = true;
            var index = 0;
            foreach (var dto in actualResult)
            {
                if (dto.Name != expectedResult[index++].Name)
                {
                    dishesAreSorted = false;
                    break;
                }
            }

            Assert.That(dishesAreSorted, Is.True);
        }
    }
}
