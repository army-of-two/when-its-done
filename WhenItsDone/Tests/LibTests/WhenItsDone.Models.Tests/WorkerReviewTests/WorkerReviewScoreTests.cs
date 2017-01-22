using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.WorkerReviewTests
{
    [TestFixture]
    public class WorkerReviewScoreTests
    {
        [Test]
        public void Score_ShouldHave_RangeAttribute()
        {
            var obj = new WorkerReview();

            var result = obj.GetType()
                            .GetProperty("Score")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Score_shouldHave_RightMinValueFor_RangeAttribute()
        {
            var obj = new WorkerReview();

            var result = obj.GetType()
                            .GetProperty("Score")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.ScoreMinValue, result.Minimum);
        }

        [Test]
        public void Score_shouldHave_RightMaxValueFor_RangeAttribute()
        {
            var obj = new WorkerReview();

            var result = obj.GetType()
                            .GetProperty("Score")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                            .Select(x => (System.ComponentModel.DataAnnotations.RangeAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.ScoreMaxValue, result.Maximum);
        }

        [TestCase(1212125)]
        [TestCase(-555)]
        public void Score_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new WorkerReview();

            obj.Score = randomNumber;

            Assert.AreEqual(randomNumber, obj.Score);
        }
    }
}
