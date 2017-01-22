using System;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models.Contracts;
using WhenItsDone.Services.Abstraction;

namespace WhenItsDone.Services.Tests.AbstractionTests.GenericAsyncServiceTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenItemParameterIsNull()
        {
            var asyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var unitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var genericAsyncService = new GenericAsyncService<IDbModel>(asyncRepository.Object, unitOfWorkFactory.Object);

            IDbModel invalidItem = null;

            Assert.That(
                () => genericAsyncService.Update(invalidItem),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Invalid item to add!"));
        }

        [Test]
        public void ShouldInvokeAsyncRepositoryUpdateMethodOnce_WhenParametersAreCorrect()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();

            var mockUnitOfWork = new Mock<IDisposableUnitOfWork>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            mockUnitOfWorkFactory.Setup(factory => factory.CreateUnitOfWork()).Returns(mockUnitOfWork.Object);

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            var validItem = new Mock<IDbModel>();
            genericAsyncService.Update(validItem.Object);

            mockAsyncRepository.Verify(repo => repo.Update(It.IsAny<IDbModel>()), Times.Once);
        }

        [Test]
        public void ShouldInvokeAsyncRepositoryUpdateMethodWithCorrectItem_WhenParametersAreCorrect()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();

            var mockUnitOfWork = new Mock<IDisposableUnitOfWork>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            mockUnitOfWorkFactory.Setup(factory => factory.CreateUnitOfWork()).Returns(mockUnitOfWork.Object);

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            var validItem = new Mock<IDbModel>();
            genericAsyncService.Update(validItem.Object);

            mockAsyncRepository.Verify(repo => repo.Update(validItem.Object), Times.Once);
        }

        [Test]
        public void ShouldInvokeIDisposableUnitOfWorkFactoryCreateUnitOfWorkMethodOnce_WhenParametersAreCorrect()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();

            var mockUnitOfWork = new Mock<IDisposableUnitOfWork>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            mockUnitOfWorkFactory.Setup(factory => factory.CreateUnitOfWork()).Returns(mockUnitOfWork.Object);

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            var validItem = new Mock<IDbModel>();
            genericAsyncService.Update(validItem.Object);

            mockUnitOfWorkFactory.Verify(repo => repo.CreateUnitOfWork(), Times.Once);
        }

        [Test]
        public void ShouldInvokeUnitOfWorkSaveChangesAsyncMethodOnce_WhenParametersAreCorrect()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();

            var mockUnitOfWork = new Mock<IDisposableUnitOfWork>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            mockUnitOfWorkFactory.Setup(factory => factory.CreateUnitOfWork()).Returns(mockUnitOfWork.Object);

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            var validItem = new Mock<IDbModel>();
            genericAsyncService.Update(validItem.Object);

            mockUnitOfWork.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void ShouldReturnTheCorrectItem_WhenParametersAreCorrect()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();

            var mockUnitOfWork = new Mock<IDisposableUnitOfWork>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            mockUnitOfWorkFactory.Setup(factory => factory.CreateUnitOfWork()).Returns(mockUnitOfWork.Object);

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            var validItem = new Mock<IDbModel>();
            var actualResult = genericAsyncService.Update(validItem.Object);

            Assert.That(actualResult, Is.EqualTo(validItem.Object));
        }
    }
}
