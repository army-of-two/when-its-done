using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Repositories;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Data.Tests.RepositoriesTests.AsyncGenericRepositoryTests
{
    [TestFixture]
    public class GetAllFilterOrderBy_Should
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenFilterParameterIsNull()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new GenericAsyncRepository<IDbModel>(mockDbContext.Object);

            // Setup data
            var fakeData = new List<IDbModel>()
            {
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            Expression<Func<IDbModel, bool>> filter = null;
            Expression<Func<IDbModel, int>> orderBy = (IDbModel model) => model.Id;

            Assert.That(
                () => asyncGenericRepositoryInstace.GetAll(filter, orderBy),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(filter)));
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenOrderByParameterIsNull()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new GenericAsyncRepository<IDbModel>(mockDbContext.Object);

            // Setup data
            var fakeData = new List<IDbModel>()
            {
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id == 1;
            Expression<Func<IDbModel, int>> orderBy = null;

            Assert.That(
                () => asyncGenericRepositoryInstace.GetAll(filter, orderBy),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(orderBy)));
        }

        [Test]
        public void ShouldReturnTaskWithResultCountZero_WhenItemIsNotFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new GenericAsyncRepository<IDbModel>(mockDbContext.Object);

            // Setup data
            var fakeData = new List<IDbModel>()
            {
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object,
               new Mock<IDbModel>().Object
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id == 1;
            Expression<Func<IDbModel, int>> orderBy = (IDbModel model) => model.Id;

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAll(filter, orderBy);

            Assert.That(actualReturnedCollection.Result.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldReturnTaskWithCorrectResult_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new GenericAsyncRepository<IDbModel>(mockDbContext.Object);

            // Setup Data
            var fakeMatchingModel = new Mock<IDbModel>();
            fakeMatchingModel.SetupGet(model => model.Id).Returns(1);

            var fakeData = new List<IDbModel>()
            {
                fakeMatchingModel.Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id == 1;
            Expression<Func<IDbModel, int>> orderBy = (IDbModel model) => model.Id;

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAll(filter, orderBy);

            var expectedCollection = new List<IDbModel>() { fakeMatchingModel.Object };

            Assert.That(actualReturnedCollection.Result, Is.Not.Null.And.EquivalentTo(expectedCollection));
        }

        [Test]
        public void ShouldReturnTaskOfCorrectType_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new GenericAsyncRepository<IDbModel>(mockDbContext.Object);

            // Setup Data
            var fakeMatchingModel = new Mock<IDbModel>();
            fakeMatchingModel.SetupGet(model => model.Id).Returns(1);

            var fakeData = new List<IDbModel>()
            {
                fakeMatchingModel.Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id == 1;
            Expression<Func<IDbModel, int>> orderBy = (IDbModel model) => model.Id;

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAll(filter, orderBy);

            Assert.That(actualReturnedCollection.GetType(), Is.EqualTo(typeof(Task<IEnumerable<IDbModel>>)));
        }

        [Test]
        public void ShouldReturnTaskOfCorrectStatus_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new GenericAsyncRepository<IDbModel>(mockDbContext.Object);

            // Setup Data
            var fakeMatchingModel = new Mock<IDbModel>();
            fakeMatchingModel.SetupGet(model => model.Id).Returns(1);

            var fakeData = new List<IDbModel>()
            {
                fakeMatchingModel.Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id == 1;
            Expression<Func<IDbModel, int>> orderBy = (IDbModel model) => model.Id;

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAll(filter, orderBy);

            Assert.That(actualReturnedCollection.Status, Is.EqualTo(TaskStatus.Running).Or.EqualTo(TaskStatus.WaitingToRun).Or.EqualTo(TaskStatus.RanToCompletion));
        }
    }
}
