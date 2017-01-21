using NUnit.Framework;

namespace WhenItsDone.Models.Tests.JobTests
{
    [TestFixture]
    public class JobClientIdTests
    {
        [TestCase(6)]
        [TestCase(9999991)]
        public void ClientId_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Job();

            obj.ClientId = randomNumber;

            Assert.AreEqual(randomNumber, obj.ClientId);
        }
    }
}
