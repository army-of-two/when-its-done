using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.VitalStatisticsTests
{
    [TestFixture]
    public class VitalStatisticsBustSizeInCmTests
    {
        [TestCase(54353)]
        [TestCase(3)]
        public void BustSizeInCm_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new MedicalInformation();

            obj.BustSizeInCm = randomNumber;

            Assert.AreEqual(randomNumber, obj.BustSizeInCm);
        }

        [Test]
        public void BustSizeInCm_ShouldHave_RangeAttribute()
        {
            var obj = new MedicalInformation();

            var result = obj.GetType()
                            .GetProperty("BustSizeInCm")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void BustSizeInCm_ShouldHave_RightMinValueFor_RangeAttribute()
        {
            var obj = new MedicalInformation();

            var result = obj.GetType()
                            .GetProperty("BustSizeInCm")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.BustSizeMinValue, result.Minimum);
        }

        [Test]
        public void BustSizeInCm_ShouldHave_RightMaxValueFor_RangeAttribute()
        {
            var obj = new MedicalInformation();

            var result = obj.GetType()
                            .GetProperty("BustSizeInCm")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.BustSizeMaxValue, result.Maximum);
        }
    }
}
