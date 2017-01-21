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
    public class GetByIdAsync_Should
    {
        [Test]
        public void ThrowArgumentExceptionWithCorrectMessage_WhenIdParameterValueIsNegative()
        {
            // This is needed to create the instance.
            // DbContext.Set<>() returns DbSet rather than IDbSet<>.
            var ctorBindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbSetConstructor = typeof(DbSet<IDbModel>).GetConstructor(ctorBindingFlags, null, new Type[] { }, null);
            var fakeDbSet = (DbSet<IDbModel>)dbSetConstructor.Invoke(null);

            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            // This is needed to mock the IDbSet<> object.
            var mockDbSet = new Mock<IDbSet<IDbModel>>();
            var fieldName = "dbSet";
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbSetField = asyncGenericRepositoryInstace.GetType().GetField(fieldName, bindingFlags);
            dbSetField.SetValue(asyncGenericRepositoryInstace, mockDbSet.Object);

            mockDbSet.Setup(mock => mock.Find(It.IsAny<int>())).Returns<IDbModel>(null);

            var invalidId = -42;
            Assert.That(
                () => asyncGenericRepositoryInstace.GetByIdAsync(invalidId),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("Id must be a positive integer."));
        }

        [Test]
        public void ShouldInvokeDbSetFindMethodOnce_WhenParametersAreValid()
        {
            // This is needed to create the instance.
            // DbContext.Set<>() returns DbSet rather than IDbSet<>.
            var ctorBindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbSetConstructor = typeof(DbSet<IDbModel>).GetConstructor(ctorBindingFlags, null, new Type[] { }, null);
            var fakeDbSet = (DbSet<IDbModel>)dbSetConstructor.Invoke(null);

            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            // This is needed to mock the IDbSet<> object.
            var mockDbSet = new Mock<IDbSet<IDbModel>>();
            var fieldName = "dbSet";
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbSetField = asyncGenericRepositoryInstace.GetType().GetField(fieldName, bindingFlags);
            dbSetField.SetValue(asyncGenericRepositoryInstace, mockDbSet.Object);

            mockDbSet.Setup(mock => mock.Find(It.IsAny<int>())).Returns<IDbModel>(null);

            var validId = 42;
            asyncGenericRepositoryInstace.GetByIdAsync(validId);

            mockDbSet.Verify(mock => mock.Find(It.IsAny<int>()), Times.Once());
        }
    }
}
