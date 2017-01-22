using System.Collections.Generic;
using System.Threading.Tasks;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models.Contracts;
using WhenItsDone.Services.Abstraction;

namespace WhenItsDone.Services.Tests.AbstractionTests.GenericAsyncServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ShouldInvokeAsyncRepository_GetAllAsyncMethodOnce()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();

            var mockUnitOfWork = new Mock<IDisposableUnitOfWork>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            mockUnitOfWorkFactory.Setup(factory => factory.CreateUnitOfWork()).Returns(mockUnitOfWork.Object);

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            genericAsyncService.GetAll();

            mockAsyncRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Test]
        public void ShouldReturnValueOfCorrectType()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            mockAsyncRepository.Setup(repo => repo.GetAllAsync()).Returns(() =>
            {
                IEnumerable<IDbModel> result = new List<IDbModel>();
                return Task.Run(() => result);
            });

            var mockUnitOfWork = new Mock<IDisposableUnitOfWork>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            mockUnitOfWorkFactory.Setup(factory => factory.CreateUnitOfWork()).Returns(mockUnitOfWork.Object);

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            var actualResult = genericAsyncService.GetAll();

            Assert.That(actualResult, Is.InstanceOf<IEnumerable<IDbModel>>());
        }

        [Test]
        public void ShouldReturnTheResultOfTheRepositoryTask()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();

            IEnumerable<IDbModel> repositoryQueryResult = new List<IDbModel>();
            mockAsyncRepository.Setup(repo => repo.GetAllAsync()).Returns(() => Task.Run(() => repositoryQueryResult));

            var mockUnitOfWork = new Mock<IDisposableUnitOfWork>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            mockUnitOfWorkFactory.Setup(factory => factory.CreateUnitOfWork()).Returns(mockUnitOfWork.Object);

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            var actualResult = genericAsyncService.GetAll();

            Assert.That(actualResult, Is.EqualTo(repositoryQueryResult));
        }
    }
}
