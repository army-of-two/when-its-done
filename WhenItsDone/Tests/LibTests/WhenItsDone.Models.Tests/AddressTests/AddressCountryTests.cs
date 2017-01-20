using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.AddressTests
{
    [TestFixture]
    public class AddressCountryTests
    {
        [Test]
        public void Country_ShouldHave_RequiredAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Country")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RequiredAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Country_ShouldHave_MinLengthAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Country")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Country_ShouldHave_RightValue_InMinLengthAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Country")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Select(x => (MinLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.CountryMinLength, result.Length);
        }

        [Test]
        public void Country_ShouldHave_MaxLengthAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Country")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Country_ShouldHave_RightValue_InMaxLengthAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Country")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Select(x => (MaxLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.CountryMaxLength, result.Length);
        }

        [Test]
        public void Country_ShouldHave_RegularExpressionAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Country")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RegularExpressionAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Country_ShouldHave_RightValue_InRegularExpressionAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Country")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RegularExpressionAttribute))
                            .Select(x => (RegularExpressionAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(RegexConstants.EnBgSpaceMinus, result.Pattern);
        }
    }
}
