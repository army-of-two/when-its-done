using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
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
            // This is needed to create the instance.
            // DbContext.Set<>() returns DbSet rather than IDbSet<>.
            var ctorParameters = new Type[] { };
            var ctorBindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbSetConstructor = typeof(DbSet<IDbModel>).GetConstructor(ctorBindingFlags, null, ctorParameters, null);
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

            var fakeData = new List<IDbModel>();
            mockDbSet.Setup(mock => mock.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAllAsync();

            Assert.That(actualReturnedCollection.Result.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldReturnTaskWithCorrectResult_WhenItemIsFound()
        {
            // This is needed to create the instance.
            // DbContext.Set<>() returns DbSet rather than IDbSet<>.
            var ctorParameters = new Type[] { };
            var ctorBindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbSetConstructor = typeof(DbSet<IDbModel>).GetConstructor(ctorBindingFlags, null, ctorParameters, null);
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

            var fakeData = new List<IDbModel>()
            {
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object
            };
            mockDbSet.Setup(mock => mock.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAllAsync();

            Assert.That(actualReturnedCollection.Result, Is.Not.Null.And.EqualTo(fakeData));
        }

        [Test]
        public void ShouldReturnTaskOfCorrectType_WhenItemIsFound()
        {
            // This is needed to create the instance.
            // DbContext.Set<>() returns DbSet rather than IDbSet<>.
            var ctorParameters = new Type[] { };
            var ctorBindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbSetConstructor = typeof(DbSet<IDbModel>).GetConstructor(ctorBindingFlags, null, ctorParameters, null);
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

            var fakeData = new List<IDbModel>()
            {
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object
            };
            mockDbSet.Setup(mock => mock.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAllAsync();

            Assert.That(actualReturnedCollection.GetType(), Is.EqualTo(typeof(Task<IEnumerable<IDbModel>>)));
        }

        [Test]
        public void ShouldReturnTaskOfCorrectStatus_WhenItemIsFound()
        {
            // This is needed to create the instance.
            // DbContext.Set<>() returns DbSet rather than IDbSet<>.
            var ctorParameters = new Type[] { };
            var ctorBindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbSetConstructor = typeof(DbSet<IDbModel>).GetConstructor(ctorBindingFlags, null, ctorParameters, null);
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

            var fakeData = new List<IDbModel>()
            {
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object,
                new Mock<IDbModel>().Object
            };
            mockDbSet.Setup(mock => mock.GetEnumerator()).Returns(fakeData.GetEnumerator());

            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAllAsync();

            Assert.That(actualReturnedCollection.Status, Is.EqualTo(TaskStatus.Running).Or.EqualTo(TaskStatus.WaitingToRun).Or.EqualTo(TaskStatus.RanToCompletion));
        }
    }
}
