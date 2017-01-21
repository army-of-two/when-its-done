using System.Data.Entity;

using NUnit.Framework;

using WhenItsDone.Data.Contracts;

namespace WhenItsDone.Data.Tests.WhenItsDoneDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldCreateAValidCorrectInstanceOfDbContext()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            Assert.That(whenItsDoneDbContext, Is.InstanceOf<DbContext>());
        }

        [Test]
        public void ShouldCreateAValidCorrectInstanceOfIWhenItsDoneDbContext()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            Assert.That(whenItsDoneDbContext, Is.InstanceOf<IWhenItsDoneDbContext>());
        }
    }
}
