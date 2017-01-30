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
    }
}
