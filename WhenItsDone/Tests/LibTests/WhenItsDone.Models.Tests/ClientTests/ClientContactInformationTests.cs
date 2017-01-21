using Moq;
using NUnit.Framework;
using System.Linq;

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

        [Test]
        public void ContactInformation_ShouldBe_Virtual()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("ContactInformation")
                            .GetAccessors()
                            .Any(x => x.IsVirtual);

            Assert.IsTrue(result);
        }
    }
}
