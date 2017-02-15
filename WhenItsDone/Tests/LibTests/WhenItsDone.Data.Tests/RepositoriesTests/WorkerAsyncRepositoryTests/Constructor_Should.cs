using Moq;
using NUnit.Framework;
using System.Data.Entity;
using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Repositories;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Tests.RepositoriesTests.WorkerAsyncRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Create_Instance_When_ParametersAre_Valid()
        {
            var mockedSet = new Mock<DbSet<Worker>>();

            var mockedContext = new Mock<IWhenItsDoneDbContext>();
            mockedContext.Setup(x => x.Set<Worker>()).Returns(mockedSet.Object);

            var obj = new WorkerAsyncRepository(mockedContext.Object);

            Assert.IsInstanceOf<WorkerAsyncRepository>(obj);
        }
    }
}
