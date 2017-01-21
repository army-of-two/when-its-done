using NUnit.Framework;

namespace WhenItsDone.Models.Tests.PaymentTests
{
    [TestFixture]
    public class PaymentConstructorTests
    {
        [Test]
        public void PaymentClass_ShouldHave_ParameterlessConstructor()
        {
            var obj = new Payment();

            Assert.IsInstanceOf<Payment>(obj);
        }

        [Test]
        public void Coonstructor_ShouldNotSet_IdProperty()
        {
            var obj = new Payment();

            Assert.AreEqual(0, obj.Id);
        }

        [Test]
        public void Coonstructor_ShouldNotSet_IsDeletedProperty()
        {
            var obj = new Payment();

            Assert.AreEqual(false, obj.IsDeleted);
        }

        [Test]
        public void Coonstructor_ShouldNotSet_WorkerIdProperty()
        {
            var obj = new Payment();

            Assert.AreEqual(0, obj.WorkerId);
        }

        [Test]
        public void Coonstructor_ShouldNotSet_WorkerProperty()
        {
            var obj = new Payment();

            Assert.AreEqual(null, obj.Worker);
        }

        [Test]
        public void Coonstructor_ShouldNotSet_AmountPaidProperty()
        {
            var obj = new Payment();

            Assert.AreEqual(0, obj.AmountPaid);
        }
    }
}
