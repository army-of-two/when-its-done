using Moq;
using NUnit.Framework;

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
    }
}
