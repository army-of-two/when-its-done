using System.Data.Entity;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Repositories;
using WhenItsDone.Models.Contracts;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Tests.RepositoriesTests.DishesAsyncRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldCreateAnObjectWhichImplementsIAsyncRepository()
        {
            var fakeDbSet = new Mock<DbSet<Dish>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<Dish>()).Returns(fakeDbSet.Object);

            var asyncGenericRepository = new DishesAsyncRepository(mockDbContext.Object);

            Assert.That(asyncGenericRepository, Is.InstanceOf<IDishesAsyncRepository>());
        }
    }
}
