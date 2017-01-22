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
    public class GetAllAsync_Should
    {
        [Test]
        public void ShouldReturnTaskWithResultNull_WhenItemIsNotFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            var fakeData = new List<IDbModel>();
            mockDbSet.As<IDbSet<IDbModel>>().Setup(mock => mock.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAllAsync();

            Assert.That(actualReturnedCollection.Result.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldReturnTaskWithCorrectResult_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            var fakeData = new List<IDbModel>()
            {
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object
            };
            mockDbSet.As<IDbSet<IDbModel>>().Setup(mock => mock.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAllAsync();

            Assert.That(actualReturnedCollection.Result, Is.Not.Null.And.EqualTo(fakeData));
        }

        [Test]
        public void ShouldReturnTaskOfCorrectType_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            var fakeData = new List<IDbModel>()
            {
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object
            };
            mockDbSet.As<IDbSet<IDbModel>>().Setup(mock => mock.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAllAsync();

            Assert.That(actualReturnedCollection.GetType(), Is.EqualTo(typeof(Task<IEnumerable<IDbModel>>)));
        }

        [Test]
        public void ShouldReturnTaskOfCorrectStatus_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            var fakeData = new List<IDbModel>()
            {
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object
            };
            mockDbSet.As<IDbSet<IDbModel>>().Setup(mock => mock.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAllAsync();

            Assert.That(actualReturnedCollection.Status, Is.EqualTo(TaskStatus.Running).Or.EqualTo(TaskStatus.WaitingToRun).Or.EqualTo(TaskStatus.RanToCompletion));
        }
    }
}
