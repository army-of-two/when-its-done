using Moq;
using NUnit.Framework;
using System.Linq;

namespace WhenItsDone.Models.Tests.ContactInformationTests
{
    [TestFixture]
    public class ContactInformationAddressTests
    {
        [Test]
        public void Address_GetAndSetShould_WorkProperly()
        {
            var mockedAddress = new Mock<Address>();

            var obj = new ContactInformation();

            obj.Address = mockedAddress.Object;

            Assert.AreSame(mockedAddress.Object, obj.Address);
        }

        [Test]
        public void Address_ShouldBe_Virtual()
        {
            var obj = new ContactInformation();

            var result = obj.GetType()
                            .GetProperty("Address")
                            .GetAccessors()
                            .Any(x => x.IsVirtual);

            Assert.IsTrue(result);
        }
    }
}
