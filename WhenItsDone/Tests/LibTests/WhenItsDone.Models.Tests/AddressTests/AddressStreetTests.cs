using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using WhenItsDone.Models.Constants;
using System.Linq;

namespace WhenItsDone.Models.Tests.AddressTests
{
    [TestFixture]
    public class AddressStreetTests
    {
        [Test]
        public void Street_ShouldHave_RequiredAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Street")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RequiredAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Street_ShouldHave_MinLengthAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Street")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Street_ShouldHave_RightValue_InMinLengthAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Street")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Select(x => (MinLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.StreetMinLength, result.Length);
        }

        [Test]
        public void Street_ShouldHave_MaxLengthAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Street")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Street_ShouldHave_RightValue_InMaxLengthAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Street")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Select(x => (MaxLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.StreetMaxLength, result.Length);
        }

        [Test]
        public void Street_ShouldHave_RegularExpressionAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Street")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RegularExpressionAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Street_ShouldHave_RightValue_InRegularExpressionAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Street")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RegularExpressionAttribute))
                            .Select(x => (RegularExpressionAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(RegexConstants.EnBgSpaceMinus, result.Pattern);
        }

        [TestCase("Sunset")]
        [TestCase("Malinov")]
        public void Street_GetAndSetShould_WorkProperly(string randomString)
        {
            var obj = new Address();

            obj.Street = randomString;

            Assert.AreEqual(randomString, obj.Street);
        }
    }
}
