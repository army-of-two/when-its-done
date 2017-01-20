using NUnit.Framework;

namespace WhenItsDone.Models.Tests.ClientTests
{
    [TestFixture]
    public class ClientContactInformationIdTests
    {
        [TestCase(54323)]
        [TestCase(6)]
        public void ContactInformationId_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Client();

            obj.ContactInformationId = randomNumber;

            Assert.AreEqual(randomNumber, obj.ContactInformationId);
        }
    }
}
