using System;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Models.Contracts;
using WhenItsDone.Services.Abstraction;

namespace WhenItsDone.Services.Tests.AbstractionTests.GenericAsyncServiceTests
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenItemParameterIsNull()
        {
            var asyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var unitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var genericAsyncService = new GenericAsyncService<IDbModel>(asyncRepository.Object, unitOfWorkFactory.Object);

            IDbModel invalidItem = null;

            Assert.That(
                () => genericAsyncService.Add(invalidItem),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Invalid item to add!"));
        }

        [Test]
        public void ShouldInvokeAsyncRepositoryAddMethodOnce_WhenParametersAreCorrect()
        {
            var asyncRepository = new Mock<IAsyncRepository<IDbModel>>();
            var unitOfWorkFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var genericAsyncService = new GenericAsyncService<IDbModel>(asyncRepository.Object, unitOfWorkFactory.Object);

            var validItemToAdd = new Mock<IDbModel>();
            genericAsyncService.Add(validItemToAdd.Object);

            asyncRepository.Verify(repo => repo.Add(It.IsAny<IDbModel>()), Times.Once);
        }
    }
}
