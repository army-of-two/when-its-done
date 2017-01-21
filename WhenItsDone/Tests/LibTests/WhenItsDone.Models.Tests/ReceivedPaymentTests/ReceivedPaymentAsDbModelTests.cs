using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.ReceivedPaymentTests
{
    [TestFixture]
    public class ReceivedPaymentAsDbModelTests
    {
        [Test]
        public void ReceivedPayment_ShouldImplement_IDbModelInterface()
        {
            var obj = new ReceivedPayment();

            var result = obj.GetType()
                            .GetInterfaces()
                            .Where(x => x == typeof(IDbModel))
                            .Any();

            Assert.IsTrue(result);
        }
    }
}
