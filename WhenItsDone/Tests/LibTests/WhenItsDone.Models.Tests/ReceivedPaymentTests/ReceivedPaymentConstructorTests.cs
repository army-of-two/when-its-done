using NUnit.Framework;

namespace WhenItsDone.Models.Tests.ReceivedPaymentTests
{
    [TestFixture]
    public class ReceivedPaymentConstructorTests
    {
        [Test]
        public void ReceivedPayment_ShouldHave_ParameterlessConstructor()
        {
            var obj = new ReceivedPayment();

            Assert.IsInstanceOf<ReceivedPayment>(obj);
        }

        [Test]
        public void Constructor_ShouldNotSet_IdProperty()
        {
            var obj = new ReceivedPayment();

            Assert.AreEqual(0, obj.Id);
        }

        [Test]
        public void Constructor_ShouldNotSet_IsDeletedProperty()
        {
            var obj = new ReceivedPayment();

            Assert.AreEqual(false, obj.IsDeleted);
        }

        [Test]
        public void Constructor_ShouldNotSet_ClientIdProperty()
        {
            var obj = new ReceivedPayment();

            Assert.AreEqual(0, obj.ClientId);
        }

        [Test]
        public void Constructor_ShouldNotSet_ClientProperty()
        {
            var obj = new ReceivedPayment();

            Assert.AreEqual(null, obj.Client);
        }

        [Test]
        public void Constructor_ShouldNotSet_AmountPaidProperty()
        {
            var obj = new ReceivedPayment();

            Assert.AreEqual(0, obj.AmountPaid);
        }
    }
}
