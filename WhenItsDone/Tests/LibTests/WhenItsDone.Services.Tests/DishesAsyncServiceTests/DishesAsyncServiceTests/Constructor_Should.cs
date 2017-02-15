using System;
using System.Reflection;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services.Tests.DishesAsyncServiceTests.DishesAsyncServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenAsycnRepositoryParameterIsNull()
        {
            IDishesAsyncRepository asyncRepository = null;
            var unitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            var usersRepository = new Mock<IUsersAsyncRepository>();

            Assert.That(
                () => new DishesAsyncService(asyncRepository, usersRepository.Object, unitOfWorkFactory.Object),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(asyncRepository)));
        }

        [Test]
        public void ShouldCreateAnInstaceOfIDishesAsyncService_WhenParametersAreCorrect()
        {
            var asyncRepository = new Mock<IDishesAsyncRepository>();
            var unitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            var usersRepository = new Mock<IUsersAsyncRepository>();

            var actualInstace = new DishesAsyncService(asyncRepository.Object, usersRepository.Object, unitOfWorkFactory.Object);

            Assert.That(actualInstace, Is.Not.Null.And.InstanceOf<IDishesAsyncService>());
        }

        [Test]
        public void ShouldAssignFieldDishesAsyncRepositoryCorrectly_WhenParametersAreCorrect()
        {
            var asyncRepository = new Mock<IDishesAsyncRepository>();
            var unitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            var usersRepository = new Mock<IUsersAsyncRepository>();

            var actualInstace = new DishesAsyncService(asyncRepository.Object, usersRepository.Object, unitOfWorkFactory.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dishesAsyncRepositoryField = typeof(DishesAsyncService).GetField("dishesAsyncRepository", bindingFlags);
            var dishesAsyncRepositoryValue = dishesAsyncRepositoryField.GetValue(actualInstace);

            Assert.That(dishesAsyncRepositoryValue, Is.Not.Null);
        }

        [Test]
        public void ShouldAssignFieldDishesAsyncRepositoryWithCorrectType_WhenParametersAreCorrect()
        {
            var asyncRepository = new Mock<IDishesAsyncRepository>();
            var unitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();
            var usersRepository = new Mock<IUsersAsyncRepository>();

            var actualInstace = new DishesAsyncService(asyncRepository.Object, usersRepository.Object, unitOfWorkFactory.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dishesAsyncRepositoryField = typeof(DishesAsyncService).GetField("dishesAsyncRepository", bindingFlags);

            Assert.That(dishesAsyncRepositoryField.FieldType, Is.EqualTo(typeof(IDishesAsyncRepository)));
        }
    }
}
