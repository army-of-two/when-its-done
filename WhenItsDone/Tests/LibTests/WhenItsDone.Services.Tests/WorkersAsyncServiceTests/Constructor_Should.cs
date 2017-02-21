using Moq;
using NUnit.Framework;
using System;
using System.Reflection;
using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models;
using WhenItsDone.Services.Factories;

namespace WhenItsDone.Services.Tests.WorkersAsyncServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        // no matter base have same test the class keep reference of repo and test should exsist
        [Test]
        public void Throw_ArgumentNullException_WhenWorkerRepo_IsNull()
        {
            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();

            var mockedContactRepo = new Mock<IAsyncRepository<ContactInformation>>();
            var mockedAddressRepo = new Mock<IAsyncRepository<Address>>();

            Assert.Throws<ArgumentNullException>(() => new WorkersAsyncService(null, mockedFactory.Object,
                        mockedModelFactory.Object, mockedContactRepo.Object, mockedAddressRepo.Object));
        }

        [Test]
        public void Throw_ArgumentNullException_WhenContactRepo_IsNull()
        {
            var mockedWorkerRepo = new Mock<IWorkerAsyncRepository>();

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();

            var mockedAddressRepo = new Mock<IAsyncRepository<Address>>();

            Assert.Throws<ArgumentNullException>(() => new WorkersAsyncService(mockedWorkerRepo.Object, mockedFactory.Object,
                        mockedModelFactory.Object, null, mockedAddressRepo.Object));
        }

        [Test]
        public void Throw_ArgumentNullException_WhenAddressRepo_IsNull()
        {
            var mockedWorkerRepo = new Mock<IWorkerAsyncRepository>();

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();

            var mockedContactRepo = new Mock<IAsyncRepository<ContactInformation>>();

            Assert.Throws<ArgumentNullException>(() => new WorkersAsyncService(mockedWorkerRepo.Object, mockedFactory.Object,
                        mockedModelFactory.Object, mockedContactRepo.Object, null));
        }


        [Test]
        public void Throw_ArgumentNullException_WhenModelFactory_IsNull()
        {
            var mockedWorkerRepo = new Mock<IWorkerAsyncRepository>();

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedContactRepo = new Mock<IAsyncRepository<ContactInformation>>();
            var mockedAddressRepo = new Mock<IAsyncRepository<Address>>();

            Assert.Throws<ArgumentNullException>(() => new WorkersAsyncService(mockedWorkerRepo.Object, mockedFactory.Object,
                        null, mockedContactRepo.Object, mockedAddressRepo.Object));
        }

        [Test]
        public void Assign_WorkerRepoField_WhenParameters_AreCorect()
        {
            var mockedWorkerRepo = new Mock<IWorkerAsyncRepository>();

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();
            var mockedContactRepo = new Mock<IAsyncRepository<ContactInformation>>();
            var mockedAddressRepo = new Mock<IAsyncRepository<Address>>();

            var obj = new WorkersAsyncService(mockedWorkerRepo.Object, mockedFactory.Object,
                        mockedModelFactory.Object, mockedContactRepo.Object, mockedAddressRepo.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

            var repoField = typeof(WorkersAsyncService)
                                .GetField("workerRepo", bindingFlags)
                                .GetValue(obj);

            Assert.AreSame(mockedWorkerRepo.Object, repoField);
        }

        [Test]
        public void Should_Call_Base_WithSameRepo_WhenArguments_AreValid()
        {
            var mockedWorkerRepo = new Mock<IWorkerAsyncRepository>();

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();
            var mockedContactRepo = new Mock<IAsyncRepository<ContactInformation>>();
            var mockedAddressRepo = new Mock<IAsyncRepository<Address>>();

            var obj = new WorkersAsyncService(mockedWorkerRepo.Object, mockedFactory.Object,
                        mockedModelFactory.Object, mockedContactRepo.Object, mockedAddressRepo.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

            var repoField = typeof(WorkersAsyncService)
                                .BaseType
                                .GetField("asyncRepository", bindingFlags)
                                .GetValue(obj);

            Assert.AreSame(mockedWorkerRepo.Object, repoField);
        }

        [Test]
        public void Should_Call_Base_WithSameFactory_WhenArguments_AreValid()
        {
            var mockedWorkerRepo = new Mock<IWorkerAsyncRepository>();

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();
            var mockedContactRepo = new Mock<IAsyncRepository<ContactInformation>>();
            var mockedAddressRepo = new Mock<IAsyncRepository<Address>>();

            var obj = new WorkersAsyncService(mockedWorkerRepo.Object, mockedFactory.Object,
                        mockedModelFactory.Object, mockedContactRepo.Object, mockedAddressRepo.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

            var factoryField = typeof(WorkersAsyncService)
                                .BaseType
                                .GetField("unitOfWorkFactory", bindingFlags)
                                .GetValue(obj);

            Assert.AreSame(mockedFactory.Object, factoryField);
        }

        [Test]
        public void Assign_ContactRepoField_WhenParameters_AreCorect()
        {
            var mockedWorkerRepo = new Mock<IWorkerAsyncRepository>();

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();
            var mockedContactRepo = new Mock<IAsyncRepository<ContactInformation>>();
            var mockedAddressRepo = new Mock<IAsyncRepository<Address>>();

            var obj = new WorkersAsyncService(mockedWorkerRepo.Object, mockedFactory.Object,
                        mockedModelFactory.Object, mockedContactRepo.Object, mockedAddressRepo.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

            var repoField = typeof(WorkersAsyncService)
                                .GetField("contactsRepo", bindingFlags)
                                .GetValue(obj);

            Assert.AreSame(mockedContactRepo.Object, repoField);
        }

        [Test]
        public void Assign_AddressRepoField_WhenParameters_AreCorect()
        {
            var mockedWorkerRepo = new Mock<IWorkerAsyncRepository>();

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();
            var mockedContactRepo = new Mock<IAsyncRepository<ContactInformation>>();
            var mockedAddressRepo = new Mock<IAsyncRepository<Address>>();

            var obj = new WorkersAsyncService(mockedWorkerRepo.Object, mockedFactory.Object,
                        mockedModelFactory.Object, mockedContactRepo.Object, mockedAddressRepo.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

            var repoField = typeof(WorkersAsyncService)
                                .GetField("addressRepo", bindingFlags)
                                .GetValue(obj);

            Assert.AreSame(mockedAddressRepo.Object, repoField);
        }


        [Test]
        public void Assign_modelFactoryField_WhenParameters_AreCorect()
        {
            var mockedWorkerRepo = new Mock<IWorkerAsyncRepository>();

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();
            var mockedContactRepo = new Mock<IAsyncRepository<ContactInformation>>();
            var mockedAddressRepo = new Mock<IAsyncRepository<Address>>();

            var obj = new WorkersAsyncService(mockedWorkerRepo.Object, mockedFactory.Object,
                        mockedModelFactory.Object, mockedContactRepo.Object, mockedAddressRepo.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

            var repoField = typeof(WorkersAsyncService)
                                .GetField("modelFactory", bindingFlags)
                                .GetValue(obj);

            Assert.AreSame(mockedModelFactory.Object, repoField);
        }
    }
}
