using NUnit.Framework;

namespace WhenItsDone.Models.Tests.ContactInformationTests
{
    [TestFixture]
    public class ContactInformationAddressIdTests
    {
        [TestCase(8)]
        [TestCase(532532)]
        public void AddressId_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new ContactInformation();

            obj.AddressId = randomNumber;

            Assert.AreEqual(randomNumber, obj.AddressId);
        }
    }
}
