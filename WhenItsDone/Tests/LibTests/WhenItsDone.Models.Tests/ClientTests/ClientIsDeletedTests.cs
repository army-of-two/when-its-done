using NUnit.Framework;

namespace WhenItsDone.Models.Tests.ClientTests
{
    [TestFixture]
    public class ClientIsDeletedTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_GetAndSetShould_WorkProperly(bool value)
        {
            var obj = new Client();

            obj.IsDeleted = value;

            Assert.AreEqual(value, obj.IsDeleted);
        }
    }
}
