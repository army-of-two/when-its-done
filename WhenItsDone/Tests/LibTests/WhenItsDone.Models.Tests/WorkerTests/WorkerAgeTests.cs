using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerAgeTests
    {
        [Test]
        public void Age_ShouldHave_RangeAttribute()
        {
            var obj = new Worker();

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
            var obj = new Worker();

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
            var obj = new Worker();

            var result = obj.GetType()
                            .GetProperty("Age")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.AgeMaxValue, result.Maximum);
        }

        [TestCase(8432)]
        [TestCase(43143)]
        public void Age_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Worker();

            obj.Age = randomNumber;

            Assert.AreEqual(randomNumber, obj.Age);
        }
    }
}
