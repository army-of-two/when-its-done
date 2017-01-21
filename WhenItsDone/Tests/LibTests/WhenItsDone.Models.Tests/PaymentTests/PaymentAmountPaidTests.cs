using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.PaymentTests
{
    [TestFixture]
    public class PaymentAmountPaidTests
    {
        [Test]
        public void AmountPaid_ShouldHave_RangeAttribute()
        {
            var obj = new Payment();

            var result = obj.GetType()
                            .GetProperty("AmountPaid")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void AmountPaid_ShouldHave_RightMinValueFor_RangeAttribute()
        {
            var obj = new Payment();

            var result = obj.GetType()
                            .GetProperty("AmountPaid")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.AmountPaidMinValue, result.Minimum);
        }

        [Test]
        public void AmountPaid_ShouldHave_RightMaxValueFor_RangeAttribute()
        {
            var obj = new Payment();

            var result = obj.GetType()
                            .GetProperty("AmountPaid")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.AmountPaidMaxValue, result.Maximum);
        }

        [TestCase(3532)]
        [TestCase(1)]
        public void AmountPaid_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Payment();

            obj.AmountPaid = randomNumber;

            Assert.AreEqual(randomNumber, obj.AmountPaid);
        }
    }
}
