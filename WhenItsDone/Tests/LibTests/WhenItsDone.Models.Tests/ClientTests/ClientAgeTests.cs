using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.ClientTests
{
    [TestFixture]
    public class ClientAgeTests
    {
        [Test]
        public void Age_ShouldHave_RangeAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("Age")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Age_ShouldHave_RightMinValueFor_RangeAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("Age")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.AgeMinValue, result.Minimum);
        }

        [Test]
        public void Age_ShouldHave_RightMaxValueFor_RangeAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("Age")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.AgeMinValue, result.Maximum);
        }

        [TestCase(8)]
        [TestCase(7000)]
        public void Age_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Client();

            obj.Age = randomNumber;

            Assert.AreEqual(randomNumber, obj.Age);
        }
    }
}
