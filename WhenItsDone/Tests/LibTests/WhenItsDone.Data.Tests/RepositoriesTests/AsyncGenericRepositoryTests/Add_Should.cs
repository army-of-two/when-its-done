using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Runtime.Serialization;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Repositories;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Data.Tests.RepositoriesTests.AsyncGenericRepositoryTests
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenEntityParameterIsNull()
        {
            // Arange
            IDbModel entity = null;
            
            var fakeDbSet = new Mock<DbSet<IDbModel>>();
            
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            // Act & Assert
            Assert.That(
                () => asyncGenericRepositoryInstace.Add(entity),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(entity)));
        }

        [Test]
        public void InvokeDbContextGetStatefulMethodOnce_WhenParametersAreValid()
        {
            // Arange
            var mockedStaful = new Mock<IStateful<IDbModel>>();

            var fakeDbSet = new Mock<DbSet<IDbModel>>();

            var fakeDbModel = new Mock<IDbModel>();
            
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);
            mockDbContext.Setup(mock => mock.GetStateful(It.IsAny<IDbModel>())).Returns(mockedStaful.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            // Act
            asyncGenericRepositoryInstace.Add(fakeDbModel.Object);

            // Assert
            mockDbContext.Verify(mock => mock.GetStateful(It.IsAny<IDbModel>()), Times.Once());
        }

        [Test]
        public void InvokeDbContextGetStatefulMethodWithCorrectParameter_WhenParametersAreValid()
        {
            // Arange
            var mockedStaful = new Mock<IStateful<IDbModel>>();

            var fakeDbSet = new Mock<DbSet<IDbModel>>();

            var fakeDbModel = new Mock<IDbModel>();

            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);
            mockDbContext.Setup(mock => mock.GetStateful(It.IsAny<IDbModel>())).Returns(mockedStaful.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            // Act
            asyncGenericRepositoryInstace.Add(fakeDbModel.Object);

            // Assert
            mockDbContext.Verify(mock => mock.GetStateful(fakeDbModel.Object), Times.Once());
        }

        [Test]
        public void ChangeStateOf_Stateful_WhenCalledWithValidParameters()
        {
            // Arange
            var mockedStaful = new Mock<IStateful<IDbModel>>();
            mockedStaful.SetupSet(x => x.State = EntityState.Added).Verifiable();

            var fakeDbSet = new Mock<DbSet<IDbModel>>();

            var fakeDbModel = new Mock<IDbModel>();


            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);
            mockDbContext.Setup(mock => mock.GetStateful(It.IsAny<IDbModel>())).Returns(mockedStaful.Object);

            var asyncGenericRepositoryInstace = new AsyncGenericRepository<IDbModel>(mockDbContext.Object);

            // Act
            asyncGenericRepositoryInstace.Add(fakeDbModel.Object);

            // Assert
            mockedStaful.Verify();
        }
    }
}
