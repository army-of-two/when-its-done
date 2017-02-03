using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.MedicalInformationTests
{
    [TestFixture]
    public class MedicalInformationHeightInCmTests
    {
        [TestCase(5)]
        [TestCase(5242199)]
        public void HeightInCm_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new MedicalInformation();

            obj.HeightInCm = randomNumber;

            Assert.AreEqual(randomNumber, obj.HeightInCm);
        }

        [Test]
        public void HeightInCm_ShouldHave_RangeAttribute()
        {
            var obj = new Worker();

            var result = obj.GetType()
                            .GetProperty("HeightInCm")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void HeightInCm_ShouldHave_RightMinValueFor_RangeAttribute()
        {
            var obj = new Worker();

            var result = obj.GetType()
                            .GetProperty("HeightInCm")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.HeightMinValue, result.Minimum);
        }

        [Test]
        public void HeightInCm_ShouldHave_RightMaxValueFor_RangeAttribute()
        {
            var obj = new Worker();

            var result = obj.GetType()
                            .GetProperty("HeightInCm")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.HeightMaxValue, result.Maximum);
        }
    }
}
