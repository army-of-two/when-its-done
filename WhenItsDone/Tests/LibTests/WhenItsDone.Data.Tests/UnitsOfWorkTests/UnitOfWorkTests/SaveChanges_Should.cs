using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork;

namespace WhenItsDone.Data.Tests.UnitsOfWorkTests.UnitOfWorkTests
{
    [TestFixture]
    public class SaveChanges_Should
    {
        [Test]
        public void InvokeDbContextSaveChangesMethodOnce()
        {
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();

            var unitOfWork = new UnitOfWork(mockDbContext.Object);

            unitOfWork.SaveChanges();

            mockDbContext.Verify(mock => mock.SaveChanges(), Times.Once());
        }

        [Test]
        public void ShouldReturnCorrectValue()
        {
            var expectedSaveChangesReturnValue = 42;
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.SaveChanges()).Returns(expectedSaveChangesReturnValue);

            var unitOfWork = new UnitOfWork(mockDbContext.Object);

            var actualReturnValue = unitOfWork.SaveChanges();

            Assert.That(actualReturnValue, Is.EqualTo(expectedSaveChangesReturnValue));
        }
    }
}
