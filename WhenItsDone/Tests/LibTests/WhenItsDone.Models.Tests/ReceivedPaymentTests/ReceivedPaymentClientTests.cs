using Moq;
using NUnit.Framework;
using System.Linq;

namespace WhenItsDone.Models.Tests.ReceivedPaymentTests
{
    [TestFixture]
    class ReceivedPaymentClientTests
    {
        [Test]
        public void Client_GetAndSetShould_WorkProperly()
        {
            var mockedClient = new Mock<Client>();

            var obj = new ReceivedPayment();

            obj.Client = mockedClient.Object;

            Assert.AreSame(mockedClient.Object, obj.Client);
        }
        
        [Test]
        public void Client_ShouldBeVirtual()
        {
            var obj = new ReceivedPayment();

            var result = obj.GetType()
                            .GetProperty("Client")
                            .GetAccessors()
                            .Any(x => x.IsVirtual);

            Assert.IsTrue(result);
        }
    }
}
