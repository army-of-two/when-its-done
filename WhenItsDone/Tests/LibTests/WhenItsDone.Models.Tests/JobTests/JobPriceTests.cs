using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.JobTests
{
    [TestFixture]
    public class JobPriceTests
    {
        [Test]
        public void Price_ShouldHave_RequiredAttribute()
        {
            var obj = new Job();

            var result = obj.GetType()
                            .GetProperty("Price")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RequiredAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Price_ShouldHave_RangeAttribute()
        {
            var obj = new Job();

            var result = obj.GetType()
                            .GetProperty("Price")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Price_ShouldHave_RightMinValueFor_RangeAttribute()
        {
            var obj = new Job();

            var result = obj.GetType()
                            .GetProperty("Price")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.PriceMinValue, result.Minimum);
        }

        [Test]
        public void Price_ShouldHave_RightMaxValueFor_RangeAttribute()
        {
            var obj = new Job();

            var result = obj.GetType()
                            .GetProperty("Price")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.PriceMaxValue, result.Maximum);
        }

        [TestCase(53453)]
        [TestCase(4)]
        public void Price_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Job();

            obj.Price = randomNumber;

            Assert.AreEqual(randomNumber, obj.Price);
        }
    }
}
