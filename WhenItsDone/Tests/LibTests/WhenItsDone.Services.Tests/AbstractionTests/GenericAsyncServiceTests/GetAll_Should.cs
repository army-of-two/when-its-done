using System;
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
        
    }
}
