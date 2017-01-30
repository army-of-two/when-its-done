using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.DTOs.DishViews;

namespace WhenItsDone.Services.Tests.DishesAsyncServiceTests.DishesAsyncServiceTests
{
    [TestFixture]
    public class GetTopCountDishesByRating_Should
    {
        [TestCase(-1)]
        [TestCase(-42)]
        [TestCase(int.MinValue)]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenDishesCountParameterIsNegative(int dishesCount)
        {
            var asyncRepository = new Mock<IDishesAsyncRepository>();
            asyncRepository.Setup(repo => repo.GetTopCountDishesByRating(It.IsAny<int>())).Returns(Task.Run<IEnumerable<NamePhotoDishView>>(() => new List<NamePhotoDishView>()));

            var unitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var dishesAsyncService = new DishesAsyncService(asyncRepository.Object, unitOfWorkFactory.Object);

            Assert.That(
                () => dishesAsyncService.GetTopCountDishesByRating(dishesCount),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("dishesCount parameter must be greater than or equal to 0."));
        }

        [Test]
        public void ShouldInvokeAsyncRepository_GetTopCountDishesByRatingMethodOnce()
        {
            var asyncRepository = new Mock<IDishesAsyncRepository>();
            asyncRepository.Setup(repo => repo.GetTopCountDishesByRating(It.IsAny<int>())).Returns(Task.Run<IEnumerable<NamePhotoDishView>>(() => new List<NamePhotoDishView>()));

            var unitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var dishesAsyncService = new DishesAsyncService(asyncRepository.Object, unitOfWorkFactory.Object);

            var dishesCount = 3;
            dishesAsyncService.GetTopCountDishesByRating(dishesCount);

            asyncRepository.Verify(repo => repo.GetTopCountDishesByRating(It.IsAny<int>()), Times.Once);
        }

        [TestCase(0)]
        [TestCase(3)]
        [TestCase(42)]
        [TestCase(int.MaxValue)]
        public void ShouldInvokeAsyncRepository_GetTopCountDishesByRatingMethodOnceWithCorrectParameter(int dishesCount)
        {
            var asyncRepository = new Mock<IDishesAsyncRepository>();
            asyncRepository.Setup(repo => repo.GetTopCountDishesByRating(It.IsAny<int>())).Returns(Task.Run<IEnumerable<NamePhotoDishView>>(() => new List<NamePhotoDishView>()));

            var unitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var dishesAsyncService = new DishesAsyncService(asyncRepository.Object, unitOfWorkFactory.Object);

            dishesAsyncService.GetTopCountDishesByRating(dishesCount);

            asyncRepository.Verify(repo => repo.GetTopCountDishesByRating(dishesCount), Times.Once);
        }

        [Test]
        public void ShouldReturnCorrectType_WhenParameteresAreCorrect()
        {
            var asyncRepository = new Mock<IDishesAsyncRepository>();
            asyncRepository.Setup(repo => repo.GetTopCountDishesByRating(It.IsAny<int>())).Returns(Task.Run<IEnumerable<NamePhotoDishView>>(() => new List<NamePhotoDishView>()));

            var unitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var dishesAsyncService = new DishesAsyncService(asyncRepository.Object, unitOfWorkFactory.Object);

            var dishesCount = 3;
            var actualResult = dishesAsyncService.GetTopCountDishesByRating(dishesCount);

            Assert.That(actualResult, Is.InstanceOf<IEnumerable<NamePhotoDishView>>());
        }

        [Test]
        public void ShouldReturnCorrectObject_WhenParameteresAreCorrect()
        {
            var asyncRepository = new Mock<IDishesAsyncRepository>();

            IEnumerable<NamePhotoDishView> mockRepositoryResult = new List<NamePhotoDishView>() { new Mock<NamePhotoDishView>().Object };
            asyncRepository.Setup(repo => repo.GetTopCountDishesByRating(It.IsAny<int>())).Returns(Task.Run<IEnumerable<NamePhotoDishView>>(() => mockRepositoryResult));

            var unitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var dishesAsyncService = new DishesAsyncService(asyncRepository.Object, unitOfWorkFactory.Object);

            var dishesCount = 3;
            var actualResult = dishesAsyncService.GetTopCountDishesByRating(dishesCount);

            Assert.That(actualResult, Is.SameAs(mockRepositoryResult));
        }
    }
}
