using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    public class GetDeleted_Should
    {
        [Test]
        public void ShouldInvokeAsyncRepository_CorrectGetAllOnce()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);
            
            genericAsyncService.GetDeleted();

            mockAsyncRepository.Verify(repo => repo.GetAll(It.IsAny<Expression<Func<IDbModel, bool>>>()), Times.Once);
        }

        [Test]
        public void ShouldInvokeAsyncRepository_CorrectGetAllWithCorrectFilterExpression()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);
            
            genericAsyncService.GetDeleted();

            mockAsyncRepository.Verify(repo => repo.GetAll((x) => x.IsDeleted), Times.Once);
        }

        [Test]
        public void ShouldReturnValueOfCorrectType()
        {
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            mockAsyncRepository.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<IDbModel, bool>>>())).Returns(() =>
            {
                IEnumerable<IDbModel> result = new List<IDbModel>();
                return Task.Run(() => result);
            });

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);
            
            var actualResult = genericAsyncService.GetDeleted();

            Assert.That(actualResult, Is.InstanceOf<IEnumerable<IDbModel>>());
        }

        [Test]
        public void ShouldReturnTheResultOfTheRepositoryTask()
        {
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            IEnumerable<IDbModel> repositoryQueryResult = new List<IDbModel>();
            mockAsyncRepository.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<IDbModel, bool>>>())).Returns(() => Task.Run(() => repositoryQueryResult));

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);
            
            var actualResult = genericAsyncService.GetDeleted();

            Assert.That(actualResult, Is.SameAs(repositoryQueryResult));
        }
    }
}
