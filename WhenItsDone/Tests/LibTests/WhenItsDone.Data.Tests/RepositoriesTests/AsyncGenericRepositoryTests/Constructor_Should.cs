using System;
using System.Data.Entity;
using System.Reflection;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Repositories;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Data.Tests.RepositoriesTests.AsyncGenericRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenIWhenItsDoneDbContextParameterIsNull()
        {
            IWhenItsDoneDbContext invalidDbContext = null;

            Assert.That(
                () => new AsyncGenericRepository<IDbModel>(invalidDbContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("DbContext"));
        }

        [Test]
        public void ShouldInvoke_DbContextSetMethodOnce()
        {
            var dbSetConstructor = typeof(DbSet<IDbModel>).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);
            var dbSet = (DbSet<IDbModel>)dbSetConstructor.Invoke(null);

            // Return type of DbContext.Set<>() method is DbSet, rather than IDbSet
            // mocking IDbSet does not work.
            //var dbSet = new Mock<IDbSet<IDbModel>>();

            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(dbSet);

            var asyncGenericRepository = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            mockDbContext.Verify(mock => mock.Set<IDbModel>(), Times.Once);
        }

        [Test]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenDbContextDoesNotContainADbSetOfTheCorrectType()
        {
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns<DbSet<IDbModel>>(null);

            Assert.That(
                () => new AsyncGenericRepository<IDbModel>(mockDbContext.Object),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("DbContext does not contain DbSet"));
        }
    }
}
