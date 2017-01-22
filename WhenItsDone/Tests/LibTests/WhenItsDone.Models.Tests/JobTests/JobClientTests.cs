using Moq;
using NUnit.Framework;
using System.Linq;

namespace WhenItsDone.Models.Tests.JobTests
{
    [TestFixture]
    public class JobClientTests
    {
        [Test]
        public void Client_GetAndSetShould_WorkProperly()
        {
            var mockedClient = new Mock<Client>();

            var obj = new Job();

            obj.Client = mockedClient.Object;

            Assert.AreSame(mockedClient.Object, obj.Client);
        }

        [Test]
        public void Client_ShouldBe_Virtual()
        {
            var obj = new Job();

            var result = obj.GetType()
                            .GetProperty("Client")
                            .GetAccessors()
                            .Any(x => x.IsVirtual);

            Assert.IsTrue(result);
        }
    }
}
