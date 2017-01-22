using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.VitalStatisticsTests
{
    [TestFixture]
    public class VitalStatisticsWaistSizeInCmTests
    {
        [TestCase(53)]
        [TestCase(366664)]
        public void WaistSizeInCm_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new VitalStatistics();

            obj.WaistSizeInCm = randomNumber;

            Assert.AreEqual(randomNumber, obj.WaistSizeInCm);
        }

        [Test]
        public void WaistSizeInCm_ShouldHave_RangeAttribute()
        {
            var obj = new VitalStatistics();

            var result = obj.GetType()
                            .GetProperty("WaistSizeInCm")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void WaistSizeInCm_ShouldHave_RightMinValueFor_RangeAttribute()
        {
            var obj = new VitalStatistics();

            var result = obj.GetType()
                            .GetProperty("WaistSizeInCm")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.WaistSizeMinValue, result.Minimum);
        }

        [Test]
        public void WaistSizeInCm_ShouldHave_RightMaxValueFor_RangeAttribute()
        {
            var obj = new VitalStatistics();

            var result = obj.GetType()
                            .GetProperty("WaistSizeInCm")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.WaistSizeMaxValue, result.Maximum);
        }
    }
}
