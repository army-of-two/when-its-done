using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.VitalStatisticsTests
{
    [TestFixture]
    public class VitalStatisticsHipSizeInCmTests
    {
        [TestCase(54353)]
        [TestCase(3)]
        public void HipSizeInCm_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new MedicalInformation();

            obj.HipSizeInCm = randomNumber;

            Assert.AreEqual(randomNumber, obj.HipSizeInCm);
        }

        [Test]
        public void HipSizeInCm_ShouldHave_RangeAttribute()
        {
            var obj = new MedicalInformation();

            var result = obj.GetType()
                            .GetProperty("HipSizeInCm")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void HipSizeInCm_ShouldHave_RightMinValueFor_RangeAttribute()
        {
            var obj = new MedicalInformation();

            var result = obj.GetType()
                            .GetProperty("HipSizeInCm")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.HipSizeMinValue, result.Minimum);
        }

        [Test]
        public void HipSizeInCm_ShouldHave_RightMaxValueFor_RangeAttribute()
        {
            var obj = new MedicalInformation();

            var result = obj.GetType()
                            .GetProperty("HipSizeInCm")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.HipSizeMaxValue, result.Maximum);
        }
    }
}
