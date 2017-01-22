using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
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
    public class GetAllFilterPagination_Should
    {
        [Test]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenPageParameterIsNegative()
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

            //// This is needed to mock the IDbSet<> object.
            var mockDbSet = new Mock<IDbSet<IDbModel>>();
            var fieldName = "dbSet";
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbSetField = asyncGenericRepositoryInstace.GetType().GetField(fieldName, bindingFlags);
            dbSetField.SetValue(asyncGenericRepositoryInstace, mockDbSet.Object);

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
            var page = -1000;
            var pageSize = 5;

            Assert.That(
                () => asyncGenericRepositoryInstace.GetAll(filter, page, pageSize),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("Page must be a value equal to or greater than zero."));
        }

        [Test]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenPageSizeParameterIsNegative()
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

            //// This is needed to mock the IDbSet<> object.
            var mockDbSet = new Mock<IDbSet<IDbModel>>();
            var fieldName = "dbSet";
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbSetField = asyncGenericRepositoryInstace.GetType().GetField(fieldName, bindingFlags);
            dbSetField.SetValue(asyncGenericRepositoryInstace, mockDbSet.Object);

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
            var page = 1;
            var pageSize = -5;

            Assert.That(
                () => asyncGenericRepositoryInstace.GetAll(filter, page, pageSize),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("Page Size must be a value equal to or greater than zero."));
        }

        [Test]
        public void ShouldThrowArgumentNullException_WhenFilterParameterIsNull()
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

            //// This is needed to mock the IDbSet<> object.
            var mockDbSet = new Mock<IDbSet<IDbModel>>();
            var fieldName = "dbSet";
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbSetField = asyncGenericRepositoryInstace.GetType().GetField(fieldName, bindingFlags);
            dbSetField.SetValue(asyncGenericRepositoryInstace, mockDbSet.Object);

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
            var page = 0;
            var pageSize = 5;

            Assert.That(
                () => asyncGenericRepositoryInstace.GetAll(filter, page, pageSize),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(filter)));
        }

        [Test]
        public void ShouldReturnTaskWithResultCountZero_WhenItemIsNotFound()
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

            //// This is needed to mock the IDbSet<> object.
            var mockDbSet = new Mock<IDbSet<IDbModel>>();
            var fieldName = "dbSet";
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbSetField = asyncGenericRepositoryInstace.GetType().GetField(fieldName, bindingFlags);
            dbSetField.SetValue(asyncGenericRepositoryInstace, mockDbSet.Object);

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

            var page = 0;
            var pageSize = 5;
            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id == 1;
            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAll(filter, page, pageSize);

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

            var page = 0;
            var pageSize = 5;
            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id == 1;
            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAll(filter, page, pageSize);

            var expectedCollection = new List<IDbModel>() { fakeMatchingModel.Object };

            Assert.That(actualReturnedCollection.Result, Is.Not.Null.And.EquivalentTo(expectedCollection));
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

            var page = 0;
            var pageSize = 5;
            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id == 1;
            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAll(filter, page, pageSize);

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

            var page = 0;
            var pageSize = 5;
            Expression<Func<IDbModel, bool>> filter = (IDbModel model) => model.Id == 1;
            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAll(filter, page, pageSize);

            Assert.That(actualReturnedCollection.Status, Is.EqualTo(TaskStatus.Running).Or.EqualTo(TaskStatus.WaitingToRun).Or.EqualTo(TaskStatus.RanToCompletion));
        }
    }
}
