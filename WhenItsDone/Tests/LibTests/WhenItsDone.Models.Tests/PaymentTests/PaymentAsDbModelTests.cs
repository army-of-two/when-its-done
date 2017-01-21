using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.PaymentTests
{
    [TestFixture]
    public class PaymentAsDbModelTests
    {
        [Test]
        public void PaymentClass_ShouldImplement_IDbModelInterface()
        {
            var obj = new Payment();

            var result = obj.GetType()
                            .GetInterfaces()
                            .Where(x => x == typeof(IDbModel))
                            .Any();

            Assert.IsTrue(result);
        }
    }
}
