using System.Threading.Tasks;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork;

namespace WhenItsDone.Data.Tests.UnitsOfWorkTests.UnitOfWorkTests
{
    [TestFixture]
    public class SaveChangesAsync_Should
    {
        [Test]
        public void InvokeDbContextSaveChangesAsyncMethodOnce()
        {
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();

            var unitOfWork = new UnitOfWork(mockDbContext.Object);

            unitOfWork.SaveChangesAsync();

            mockDbContext.Verify(mock => mock.SaveChangesAsync(), Times.Once());
        }

        [Test]
        public void ReturnCorrectTaskValue()
        {
            var expectedTaskReturnValue = 42;
            var expectedTask = new Task<int>(() =>
            {
                return expectedTaskReturnValue;
            });

            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.SaveChangesAsync()).Returns(expectedTask);

            var unitOfWork = new UnitOfWork(mockDbContext.Object);
            var actualTask = unitOfWork.SaveChangesAsync();

            Assert.That(actualTask, Is.EqualTo(expectedTask));
        }
    }
}
