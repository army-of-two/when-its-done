using Moq;
using NUnit.Framework;
using System.Linq;

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

        [Test]
        public void ContanctInformation_ShouldBe_Virtual()
        {
            var obj = new Worker();

            var result = obj.GetType()
                            .GetProperty("ContactInformation")
                            .GetAccessors()
                            .Where(x => x.IsVirtual)
                            .Any();

            Assert.IsTrue(result);
        }
    }
}
