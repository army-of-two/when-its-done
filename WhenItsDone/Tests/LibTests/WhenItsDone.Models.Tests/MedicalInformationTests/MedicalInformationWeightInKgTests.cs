using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.MedicalInformationTests
{
    [TestFixture]
    public class MedicalInformationWeightInKgTests
    {
        [TestCase(555111)]
        [TestCase(12)]
        public void WeightInKg_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new MedicalInformation();

            obj.WeightInKg = randomNumber;

            Assert.AreEqual(randomNumber, obj.WeightInKg);
        }

        [Test]
        public void WeightInKg_ShouldHave_RangeAttribute()
        {
            var obj = new MedicalInformation();

            var result = obj.GetType()
                            .GetProperty("WeightInKg")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void WeightInKg_ShouldHave_RightMinValueFor_RangeAttribute()
        {
            var obj = new MedicalInformation();

            var result = obj.GetType()
                            .GetProperty("WeightInKg")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.WeightMinValue, result.Minimum);
        }

        [Test]
        public void WeightInKg_ShouldHave_RightMaxValueFor_RangeAttribute()
        {
            var obj = new MedicalInformation();

            var result = obj.GetType()
                            .GetProperty("WeightInKg")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.WeightMaxValue, result.Maximum);
        }
    }
}
