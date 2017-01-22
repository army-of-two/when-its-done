using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Reflection;
using System.Runtime.Serialization;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Repositories;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Data.Tests.RepositoriesTests.AsyncGenericRepositoryTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenEntityParameterIsNull()
        {
            var fakeDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            IDbModel entity = null;
            Assert.That(
                () => asyncGenericRepositoryInstace.Delete(entity),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(entity)));
        }

        [Test]
        public void InvokeDbContextEntryMethodOnce_WhenParametersAreValid()
        {
            var fakeDbSet = new Mock<DbSet<IDbModel>>();
            var entity = (DbEntityEntry<IDbModel>)FormatterServices.GetSafeUninitializedObject(typeof(DbEntityEntry<IDbModel>));
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);
            mockDbContext.Setup(mock => mock.Entry(It.IsAny<IDbModel>())).Returns(entity);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);
            var fakeDbModel = new Mock<IDbModel>();

            try
            {
                asyncGenericRepositoryInstace.Delete(fakeDbModel.Object);
            }
            catch (NullReferenceException)
            {
                // This will throw due to not being able to instantiate an InternalEntityEntry object.
                // Because of that all DbEntityEntry<T> public properties throw a NullReferenceException.

                // namespace System.Data.Entity.Internal
                // internal class InternalEntityEntry
                // https://github.com/mono/entityframework/blob/master/src/EntityFramework/Internal/EntityEntries/InternalEntityEntry.cs
            }

            mockDbContext.Verify(mock => mock.Entry(It.IsAny<IDbModel>()), Times.Once());
        }

        [Test]
        public void InvokeDbContextEntryMethodWithCorrectParameter_WhenParametersAreValid()
        {
            var fakeDbSet = new Mock<DbSet<IDbModel>>();
            var entity = (DbEntityEntry<IDbModel>)FormatterServices.GetSafeUninitializedObject(typeof(DbEntityEntry<IDbModel>));
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);
            mockDbContext.Setup(mock => mock.Entry(It.IsAny<IDbModel>())).Returns(entity);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);
            var fakeDbModel = new Mock<IDbModel>();

            try
            {
                asyncGenericRepositoryInstace.Delete(fakeDbModel.Object);
            }
            catch (NullReferenceException)
            {
                // This will throw due to not being able to instantiate an InternalEntityEntry object.
                // Because of that all DbEntityEntry<T> public properties throw a NullReferenceException.

                // namespace System.Data.Entity.Internal
                // internal class InternalEntityEntry
                // https://github.com/mono/entityframework/blob/master/src/EntityFramework/Internal/EntityEntries/InternalEntityEntry.cs
            }

            mockDbContext.Verify(mock => mock.Entry(fakeDbModel.Object), Times.Once());
        }
    }
}
