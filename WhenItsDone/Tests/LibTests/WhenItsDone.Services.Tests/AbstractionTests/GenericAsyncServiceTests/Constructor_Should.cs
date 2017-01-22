using System;
using System.Reflection;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models.Contracts;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services.Tests.AbstractionTests.GenericAsyncServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        // should throw on null
        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenIAsyncRepositoryParameterIsNull()
        {
            IAsyncRepository<IDbModel> asyncRepository = null;
            var unitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            Assert.That(
                () => new GenericAsyncService<IDbModel>(asyncRepository, unitOfWorkFactory.Object),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(asyncRepository)));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenIDisposableUnitOfWorkFactoryParameterIsNull()
        {
            var asyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            IDisposableUnitOfWorkFactory unitOfWorkFactory = null;

            Assert.That(
                () => new GenericAsyncService<IDbModel>(asyncRepository.Object, unitOfWorkFactory),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(unitOfWorkFactory)));
        }

        [Test]
        public void CreatesAValidInstance_WhenConstructorParametersAreValid()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var actualGenericAsyncServiceInstance = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            Assert.That(actualGenericAsyncServiceInstance, Is.Not.Null.And.InstanceOf<GenericAsyncService<IDbModel>>());
        }

        [Test]
        public void CreatesAValidIGenericAsyncServiceInstance_WhenConstructorParametersAreValid()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var actualGenericAsyncServiceInstance = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            Assert.That(actualGenericAsyncServiceInstance, Is.Not.Null.And.InstanceOf<IGenericAsyncService<IDbModel>>());
        }

        [Test]
        public void AssignsCorrectValueToAsyncRepositoryField_WhenParametersAreCorrect()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var genericAsyncServiceInstance = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            var fieldName = "asyncRepository";
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var asyncRepositoryField = genericAsyncServiceInstance.GetType().GetField(fieldName, bindingFlags);
            var asyncRepositoryFieldValue = asyncRepositoryField.GetValue(genericAsyncServiceInstance);

            Assert.That(asyncRepositoryFieldValue, Is.EqualTo(mockAsyncRepository.Object));
        }

        [Test]
        public void AssignsCorrectValueToUnitOfWorkFactoryField_WhenParametersAreCorrect()
        {
            var mockAsyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var mockUnitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var genericAsyncServiceInstance = new GenericAsyncService<IDbModel>(mockAsyncRepository.Object, mockUnitOfWorkFactory.Object);

            var fieldName = "unitOfWorkFactory";
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var asyncRepositoryField = genericAsyncServiceInstance.GetType().GetField(fieldName, bindingFlags);
            var asyncRepositoryFieldValue = asyncRepositoryField.GetValue(genericAsyncServiceInstance);

            Assert.That(asyncRepositoryFieldValue, Is.EqualTo(mockUnitOfWorkFactory.Object));
        }
    }
}
