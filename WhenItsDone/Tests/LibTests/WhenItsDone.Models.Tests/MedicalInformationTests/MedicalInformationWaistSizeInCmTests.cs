using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.MedicalInformationTests
{
    [TestFixture]
    public class MedicalInformationWaistSizeInCmTests
    {
        [TestCase(53)]
        [TestCase(366664)]
        public void WaistSizeInCm_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new MedicalInformation();

            obj.WaistSizeInCm = randomNumber;

            Assert.AreEqual(randomNumber, obj.WaistSizeInCm);
        }

        [Test]
        public void WaistSizeInCm_ShouldHave_RangeAttribute()
        {
            var obj = new MedicalInformation();

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
            var obj = new MedicalInformation();

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
            var obj = new MedicalInformation();

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
