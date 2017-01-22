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
using System.Linq.Expressions;

namespace WhenItsDone.Data.Tests.RepositoriesTests.AsyncGenericRepositoryTests
{
    [TestFixture]
    public class GetAllFilterTests
    {
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
            var fakeDeletedModel = new Mock<IDbModel>();
            fakeDeletedModel.SetupGet(model => model.IsDeleted).Returns(true);

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
            var actualReturnedCollection = asyncGenericRepositoryInstace.GetAll(filter);

            Assert.That(actualReturnedCollection.Result.Count, Is.EqualTo(0));
        }
    }
}
