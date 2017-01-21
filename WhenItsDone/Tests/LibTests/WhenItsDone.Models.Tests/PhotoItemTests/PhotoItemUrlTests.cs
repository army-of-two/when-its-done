using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.PhotoItemTests
{
    [TestFixture]
    public class PhotoItemUrlTests
    {
        [Test]
        public void Url_ShouldHave_RequiredAttribute()
        {
            var obj = new PhotoItem();

            var result = obj.GetType()
                            .GetProperty("Url")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RequiredAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Url_ShouldHave_MinLengthAttribute()
        {
            var obj = new PhotoItem();

            var result = obj.GetType()
                            .GetProperty("Url")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Url_ShouldHave_RightMinValueFor_RequiredAttribute()
        {
            var obj = new PhotoItem();

            var result = obj.GetType()
                            .GetProperty("Url")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Select(x => (MinLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.UrlLengthMinLength, result.Length);
        }

        [Test]
        public void Url_ShouldHave_MaxLengthAttribute()
        {
            var obj = new PhotoItem();

            var result = obj.GetType()
                            .GetProperty("Url")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Url_ShouldHave_RightMaxValueFor_RequiredAttribute()
        {
            var obj = new PhotoItem();

            var result = obj.GetType()
                            .GetProperty("Url")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Select(x => (MaxLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.UrlLengthMaxValue, result.Length);
        }

        [TestCase("Merry Christmas")]
        [TestCase("abv.bg/bg/abv/default.aspx")]
        public void Url_GetAndSetShould_WorkProperly(string randomString)
        {
            var obj = new PhotoItem();

            obj.Url = randomString;

            Assert.AreEqual(randomString, obj.Url);
        }
    }
}
