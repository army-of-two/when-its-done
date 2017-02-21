using Moq;
using NUnit.Framework;
using System;
using System.Reflection;
using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Services.Factories;

namespace WhenItsDone.Services.Tests.WorkersAsyncServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        // no matter base have same test the class keep reference of repo and test should exsist
        [Test]
        public void Throw_ArgumentNullException_WhenRepo_IsNull()
        {
            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();

            Assert.Throws<ArgumentNullException>(() => new WorkersAsyncService(null, mockedFactory.Object, mockedModelFactory.Object));
        }

        [Test]
        public void Assign_RepoField_WhenParameters_AreCorect()
        {
            var mockedRepo = new Mock<IWorkerAsyncRepository>();

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();

            var obj = new WorkersAsyncService(mockedRepo.Object, mockedFactory.Object, mockedModelFactory.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

            var repoField = typeof(WorkersAsyncService)
                                .GetField("workerRepo", bindingFlags)
                                .GetValue(obj);

            Assert.AreSame(mockedRepo.Object, repoField);
        }

        [Test]
        public void Should_Call_Base_WithSameRepo_WhenArguments_AreValid()
        {
            var mockedRepo = new Mock<IWorkerAsyncRepository>();

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();

            var obj = new WorkersAsyncService(mockedRepo.Object, mockedFactory.Object, mockedModelFactory.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

            var repoField = typeof(WorkersAsyncService)
                                .BaseType
                                .GetField("asyncRepository", bindingFlags)
                                .GetValue(obj);

            Assert.AreSame(mockedRepo.Object, repoField);
        }

        [Test]
        public void Should_Call_Base_WithSameFactory_WhenArguments_AreValid()
        {
            var mockedRepo = new Mock<IWorkerAsyncRepository>();

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();

            var obj = new WorkersAsyncService(mockedRepo.Object, mockedFactory.Object, mockedModelFactory.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

            var factoryField = typeof(WorkersAsyncService)
                                .BaseType
                                .GetField("unitOfWorkFactory", bindingFlags)
                                .GetValue(obj);

            Assert.AreSame(mockedFactory.Object, factoryField);
        }
    }
}
