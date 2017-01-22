using System;
using System.Data.Entity;
using System.Threading.Tasks;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Repositories;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Data.Tests.RepositoriesTests.AsyncGenericRepositoryTests
{
    [TestFixture]
    public class GetByIdAsync_Should
    {
        [Test]
        public void ThrowArgumentExceptionWithCorrectMessage_WhenIdParameterValueIsNegative()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            mockDbSet.Setup(mock => mock.Find(It.IsAny<int>())).Returns<IDbModel>(null);

            var invalidId = -42;
            Assert.That(
                () => asyncGenericRepositoryInstace.GetByIdAsync(invalidId),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("Id must be a positive integer."));
        }

        [Test]
        public async Task ShouldInvokeDbSetFindMethodOnce_WhenParametersAreValid()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            mockDbSet.Setup(mock => mock.Find(It.IsAny<int>())).Returns<IDbModel>(null);

            var validId = 42;
            await asyncGenericRepositoryInstace.GetByIdAsync(validId);

            mockDbSet.Verify(mock => mock.Find(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public async Task ShouldInvokeDbSetFindMethodWithCorrectIdParameter_WhenParametersAreValid()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            mockDbSet.Setup(mock => mock.Find(It.IsAny<int>())).Returns<IDbModel>(null);

            var validId = 42;
            await asyncGenericRepositoryInstace.GetByIdAsync(validId);

            mockDbSet.Verify(mock => mock.Find(validId), Times.Once());
        }

        [Test]
        public void ShouldReturnTaskWithResultNull_WhenItemIsNotFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            mockDbSet.Setup(mock => mock.Find(It.IsAny<int>())).Returns<IDbModel>(null);

            var validId = 42;
            var actualReturnedModel = asyncGenericRepositoryInstace.GetByIdAsync(validId);

            Assert.That(actualReturnedModel.Result, Is.Null);
        }

        [Test]
        public void ShouldReturnTaskWithCorrectResult_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            var fakeDbModel = new Mock<IDbModel>();
            mockDbSet.Setup(mock => mock.Find(It.IsAny<int>())).Returns(fakeDbModel.Object);

            var validId = 42;
            var actualReturnedModel = asyncGenericRepositoryInstace.GetByIdAsync(validId);

            Assert.That(actualReturnedModel.Result, Is.Not.Null.And.EqualTo(fakeDbModel.Object));
        }

        [Test]
        public void ShouldReturnTaskOfCorrectType_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            var fakeDbModel = new Mock<IDbModel>();
            mockDbSet.Setup(mock => mock.Find(It.IsAny<int>())).Returns(fakeDbModel.Object);

            var validId = 42;
            var actualReturnedModel = asyncGenericRepositoryInstace.GetByIdAsync(validId);

            Assert.That(actualReturnedModel.GetType(), Is.EqualTo(typeof(Task<IDbModel>)));
        }

        [Test]
        public void ShouldReturnTaskOfCorrectStatus_WhenItemIsFound()
        {
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(mockDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            var fakeDbModel = new Mock<IDbModel>();
            mockDbSet.Setup(mock => mock.Find(It.IsAny<int>())).Returns(fakeDbModel.Object);

            var validId = 42;
            var actualReturnedModel = asyncGenericRepositoryInstace.GetByIdAsync(validId);

            Assert.That(actualReturnedModel.Status, Is.EqualTo(TaskStatus.Running).Or.EqualTo(TaskStatus.WaitingToRun).Or.EqualTo(TaskStatus.RanToCompletion));
        }
    }
}
