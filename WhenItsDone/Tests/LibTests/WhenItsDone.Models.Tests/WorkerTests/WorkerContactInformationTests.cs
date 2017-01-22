using Moq;
using NUnit.Framework;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerContactInformationTests
    {
        [Test]
        public void ContactInformation_GetAndSetShould_WorkProperly()
        {
            var mockedVS = new Mock<ContactInformation>();

            var obj = new Worker();

            obj.ContactInformation = mockedVS.Object;

            Assert.AreSame(mockedVS.Object, obj.ContactInformation);
        }
    }
}
