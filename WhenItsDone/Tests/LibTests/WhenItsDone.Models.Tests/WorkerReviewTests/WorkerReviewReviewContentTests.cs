using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.WorkerReviewTests
{
    [TestFixture]
    public class WorkerReviewReviewContentTests
    {
        [Test]
        public void ReviewContent_ShouldHave_RequiredAttribute()
        {
            var obj = new WorkerReview();

            var result = obj.GetType()
                            .GetProperty("ReviewContent")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RequiredAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void ReviewContent_ShouldHave_MinLengthAttribute()
        {
            var obj = new WorkerReview();

            var result = obj.GetType()
                            .GetProperty("ReviewContent")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void ReviewContent_ShouldHave_RightValueFor_MinLengthAttribute()
        {
            var obj = new WorkerReview();

            var result = obj.GetType()
                            .GetProperty("ReviewContent")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Select(x => (MinLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.ReviewContentMinLength, result.Length);
        }

        [Test]
        public void ReviewContent_ShouldHave_MaxLengthAttribute()
        {
            var obj = new WorkerReview();

            var result = obj.GetType()
                            .GetProperty("ReviewContent")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void ReviewContent_ShouldHave_RightValueFor_MaxLengthAttribute()
        {
            var obj = new WorkerReview();

            var result = obj.GetType()
                            .GetProperty("ReviewContent")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Select(x => (MaxLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.ReviewContentMaxLength, result.Length);
        }

        [TestCase("icr,ewo234c3i4j.c2kl3l")]
        [TestCase("$#<>#<$#X@<$#@::321x31km")]
        public void ReviewContent_GetAndSetShould_WorkProperly(string randomString)
        {
            var obj = new WorkerReview();

            obj.ReviewContent = randomString;

            Assert.AreEqual(randomString, obj.ReviewContent);
        }
    }
}
