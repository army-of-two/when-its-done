using NUnit.Framework;

namespace WhenItsDone.Models.Tests.AddressTests
{
    [TestFixture]
    public class AddressIsDeletedTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_GetAndSetShould_WorkProperly(bool value)
        {
            var obj = new Address();

            obj.IsDeleted = value;

            Assert.AreEqual(value, obj.IsDeleted);
        }
    }
}
