using NUnit.Framework;

namespace WhenItsDone.Models.Tests.ReceivedPaymentTests
{
    [TestFixture]
    public class ReceivedPaymentIsDeletedTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_GetAndSetShould_WorkProperly(bool value)
        {
            var obj = new ReceivedPayment();

            obj.IsDeleted = value;

            Assert.AreEqual(value, obj.IsDeleted);
        }
    }
}

