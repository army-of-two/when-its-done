using System;
using System.Reflection;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork;

namespace WhenItsDone.Data.Tests.UnitsOfWorkTests.UnitOfWorkTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenDbContextParameterIsNull()
        {
            IWhenItsDoneDbContext invalidDbContextParameter = null;

            Assert.That(
                () => new UnitOfWork(invalidDbContextParameter),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("DbContext"));
        }

        [Test]
        public void NotThrow_WhenDbContextParameterIsValid()
        {
            var validDbContext = new Mock<IWhenItsDoneDbContext>();

            var actualUnitOfWorkInstace = new UnitOfWork(validDbContext.Object);

            Assert.That(actualUnitOfWorkInstace, Is.Not.Null);
        }

        [Test]
        public void CreateAnObjectImplementingIDisposableUnitOfWork_WhenParametersAreCorrect()
        {
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();

            var actualUnitOfWorkInstace = new UnitOfWork(mockDbContext.Object);

            Assert.That(actualUnitOfWorkInstace, Is.InstanceOf<IDisposableUnitOfWork>());
        }

        [Test]
        public void CreateAnObjectImplementingIUnitOfWork_WhenParametersAreCorrect()
        {
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();

            var actualUnitOfWorkInstace = new UnitOfWork(mockDbContext.Object);

            Assert.That(actualUnitOfWorkInstace, Is.InstanceOf<IUnitOfWork>());
        }

        [Test]
        public void CreateAnObjectImplementingIDisposable_WhenParametersAreCorrect()
        {
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();

            var actualUnitOfWorkInstace = new UnitOfWork(mockDbContext.Object);

            Assert.That(actualUnitOfWorkInstace, Is.InstanceOf<IDisposable>());
        }

        [Test]
        public void ShouldSetCorrectValueToPrivateFieldDbContext_WhenParametersAreCorrect()
        {
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();

            var actualUnitOfWorkInstace = new UnitOfWork(mockDbContext.Object);

            var fieldName = "dbContext";
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbContextField = actualUnitOfWorkInstace.GetType().GetField(fieldName, bindingFlags);
            var dbContextFieldValue = dbContextField.GetValue(actualUnitOfWorkInstace);

            Assert.That(dbContextFieldValue, Is.Not.Null.And.EqualTo(mockDbContext.Object));
        }
    }
}
