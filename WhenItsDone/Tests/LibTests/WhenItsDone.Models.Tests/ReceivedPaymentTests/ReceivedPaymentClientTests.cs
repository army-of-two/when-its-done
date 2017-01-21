using Moq;
using NUnit.Framework;

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
    }
}
