using NUnit.Framework;

namespace WhenItsDone.Models.Tests.PaymentTests
{
    [TestFixture]
    public class PaymentWorkerIdTests
    {
        [TestCase(99996666)]
        [TestCase(31)]
        public void WorkerId_GetAndSetShould_workProperly(int randomNumber)
        {
            var obj = new Job();

            obj.WorkerId = randomNumber;

            Assert.AreEqual(randomNumber, obj.WorkerId);
        }
    }
}
