using Moq;
using NUnit.Framework;

namespace WhenItsDone.Models.Tests.ClientTests
{
    [TestFixture]
    public class ClientContactInformationTests
    {
        [Test]
        public void ContactInformation_GetAndSetShould_WorkProperly()
        {
            var mockedInfo = new Mock<ContactInformation>();

            var obj = new Client();

            obj.ContactInformation = mockedInfo.Object;

            Assert.AreSame(mockedInfo.Object, obj.ContactInformation);
        }
    }
}
