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
            var mockedCI = new Mock<ContactInformation>();

            var obj = new Worker();

            obj.ContactInformation = mockedCI.Object;

            Assert.AreSame(mockedCI.Object, obj.ContactInformation);
        }
    }
}
