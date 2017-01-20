using NUnit.Framework;

namespace WhenItsDone.Models.Tests.ClientTests
{
    [TestFixture]
    public class ClientIsAvailableTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsAvailable_GetAndSetShould_WorkProperly(bool value)
        {
            var obj = new Client();

            obj.IsAvailable = value;

            Assert.AreEqual(value, obj.IsAvailable);
        }

    }
}
