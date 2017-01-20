using NUnit.Framework;

namespace WhenItsDone.Models.Tests.AddressTests
{
    [TestFixture]
    public class AddressIsDeletedTests
    {
        [Test]
        public void IsDeleted_InitialValue_ShouldBeFalse()
        {
            var obj = new Address();

            Assert.IsFalse(obj.IsDeleted);
        }
    }
}
