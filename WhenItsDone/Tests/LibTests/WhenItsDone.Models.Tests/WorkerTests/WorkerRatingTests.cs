using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerRatingTests
    {
        [TestCase(-18)]
        [TestCase(4113113)]
        public void Rating_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Worker();

            obj.Rating = randomNumber;

            Assert.AreEqual(randomNumber, obj.Rating);
        }

        [Test]
        public void Rating_ShouldHave_RangeAttribute()
        {
            var obj = new Worker();

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
            var obj = new Worker();

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
            var obj = new Worker();

            var result = obj.GetType()
                            .GetProperty("Rating")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.RatingMaxValue, result.Maximum);
        }
    }
}
