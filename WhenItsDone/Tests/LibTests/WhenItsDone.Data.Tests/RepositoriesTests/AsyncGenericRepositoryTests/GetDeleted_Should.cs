using System.Collections.Generic;
using System.Data.Entity;
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
    public class GetDeleted_Should
    {
        [Test]
        public void ShouldReturnTaskWithResultNull_WhenItemIsNotFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            // Setting up Linq methods
            var fakeData = new List<IDbModel>().AsQueryable();
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetDeleted();

            Assert.That(actualReturnedCollection.Result.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldReturnTaskWithCorrectResult_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            var fakeDeletedModel = new Mock<IDbModel>();
            fakeDeletedModel.SetupGet(model => model.IsDeleted).Returns(true);

            var fakeData = new List<IDbModel>()
            {
                fakeDeletedModel.Object
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetDeleted();

            Assert.That(actualReturnedCollection.Result, Is.Not.Null.And.EqualTo(fakeData));
        }

        [Test]
        public void ShouldReturnTaskOfCorrectType_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            var fakeDeletedModel = new Mock<IDbModel>();
            fakeDeletedModel.SetupGet(model => model.IsDeleted).Returns(true);

            var fakeData = new List<IDbModel>()
            {
               fakeDeletedModel.Object
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetDeleted();

            Assert.That(actualReturnedCollection.GetType(), Is.EqualTo(typeof(Task<IEnumerable<IDbModel>>)));
        }

        [Test]
        public void ShouldReturnTaskOfCorrectStatus_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            var fakeDeletedModel = new Mock<IDbModel>();
            fakeDeletedModel.SetupGet(model => model.IsDeleted).Returns(true);

            var fakeData = new List<IDbModel>()
            {
               fakeDeletedModel.Object
            }
            .AsQueryable();

            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockDbSet.As<IQueryable<IDbModel>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetDeleted();

            Assert.That(actualReturnedCollection.Status, Is.EqualTo(TaskStatus.Running).Or.EqualTo(TaskStatus.WaitingToRun).Or.EqualTo(TaskStatus.RanToCompletion));
        }
    }
}
