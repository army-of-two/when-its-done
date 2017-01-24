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
    public class GetAllFilterOrderBy_Should
    {
        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenFilterParameterIsNull()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            Expression<Func<IDbModel, bool>> filter = null;
            Expression<Func<IDbModel, int>> orderBy = (IDbModel model) => model.Id;
            Assert.That(
                () => genericAsyncService.GetAll(filter, orderBy),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(filter)));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenOrderByParameterIsNull()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id > 0;
            Expression<Func<IDbModel, int>> orderBy = null;
            Assert.That(
                () => genericAsyncService.GetAll(filter, orderBy),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(orderBy)));
        }

        [Test]
        public void ShouldInvokeAsyncRepository_CorrectGetAllOnce()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id > 0;
            Expression<Func<IDbModel, int>> orderBy = (IDbModel model) => model.Id;
            genericAsyncService.GetAll(filter, orderBy);

            mockAsyncRepository.Verify(repo => repo.GetAll(It.IsAny<Expression<Func<IDbModel, bool>>>(), It.IsAny<Expression<Func<IDbModel, int>>>()), Times.Once);
        }

        [Test]
        public void ShouldInvokeAsyncRepository_CorrectGetAllWithCorrectFilterExpression()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id > 0;
            Expression<Func<IDbModel, int>> orderBy = (IDbModel model) => model.Id;

            genericAsyncService.GetAll(filter, orderBy);

            mockAsyncRepository.Verify(repo => repo.GetAll(filter, It.IsAny<Expression<Func<IDbModel, int>>>()), Times.Once);
        }

        [Test]
        public void ShouldInvokeAsyncRepository_CorrectGetAllWithCorrectOrderByExpression()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id > 0;
            Expression<Func<IDbModel, int>> orderBy = (IDbModel model) => model.Id;

            genericAsyncService.GetAll(filter, orderBy);

            mockAsyncRepository.Verify(repo => repo.GetAll(It.IsAny<Expression<Func<IDbModel, bool>>>(), orderBy), Times.Once);
        }

        [Test]
        public void ShouldReturnValueOfCorrectType()
        {
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            IEnumerable<IDbModel> repositoryQueryResult = new List<IDbModel>();
            mockAsyncRepository.Setup(
                repo => repo.GetAll(
                    It.IsAny<Expression<Func<IDbModel, bool>>>(),
                    It.IsAny<Expression<Func<IDbModel, int>>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                .Returns(() => Task.Run(() => repositoryQueryResult));

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id > 0;
            Expression<Func<IDbModel, int>> orderBy = (IDbModel model) => model.Id;

            var actualResult = genericAsyncService.GetAll(filter, orderBy);

            Assert.That(actualResult, Is.InstanceOf<IEnumerable<IDbModel>>());
        }

        [Test]
        public void ShouldReturnTheResultOfTheRepositoryTask()
        {
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            IEnumerable<IDbModel> repositoryQueryResult = new List<IDbModel>();
            mockAsyncRepository.Setup(
                repo => repo.GetAll(
                    It.IsAny<Expression<Func<IDbModel, bool>>>(),
                    It.IsAny<Expression<Func<IDbModel, int>>>()))
                .Returns(() => Task.Run(() => repositoryQueryResult));

            var genericAsyncService = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id > 0;
            Expression<Func<IDbModel, int>> orderBy = (IDbModel model) => model.Id;

            var actualResult = genericAsyncService.GetAll(filter, orderBy);

            Assert.That(actualResult, Is.SameAs(repositoryQueryResult));
        }
    }
}
