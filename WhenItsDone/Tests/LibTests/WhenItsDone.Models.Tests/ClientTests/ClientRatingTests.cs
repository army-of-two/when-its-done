using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.ClientTests
{
    [TestFixture]
    public class ClientRatingTests
    {
        [Test]
        public void Rating_ShouldHave_RangeAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("Rating")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Rating_ShouldHave_RightMinValueFor_RangeAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("Rating")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.RatingMinValue, result.Minimum);
        }

        [Test]
        public void Rating_ShouldHave_RightMaxValueFor_RangeAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("Rating")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.RatingMaxValue, result.Maximum);
        }

        [TestCase(6)]
        [TestCase(54353453)]
        public void Rating_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Client();

            obj.Rating = randomNumber;

            Assert.AreEqual(randomNumber, obj.Rating);
        }
    }
}
