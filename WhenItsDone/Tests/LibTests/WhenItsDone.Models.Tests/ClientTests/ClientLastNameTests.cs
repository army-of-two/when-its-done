using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.ClientTests
{
    [TestFixture]
    class ClientLastNameTests
    {
        [Test]
        public void LastName_ShouldHave_RequireAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("LastName")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RequiredAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void LastName_ShouldHave_MinLengthAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("LastName")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void LastName_ShouldHave_RightValueFor_MinLengthAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("LastName")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Select(x => (MinLengthAttribute)x)
                            .FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.NameMinLength, result.Length);
        }

        [Test]
        public void LastName_ShouldHave_MaxLengthAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("LastName")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void LastName_ShouldHave_RightValueFor_MaxLengthAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("LastName")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Select(x => (MaxLengthAttribute)x)
                            .FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.NameMaxLength, result.Length);
        }

        [Test]
        public void LastName_ShouldHave_RegularExpressionAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("LastName")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RegularExpressionAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void LastName_ShouldHave_RightValueFor_RegularExpressionAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("LastName")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RegularExpressionAttribute))
                            .Select(x => (RegularExpressionAttribute)x)
                            .FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.NameMinLength, result.Pattern);
        }

        [TestCase("Here your string")]
        [TestCase("Test 2")]
        [TestCase("")]
        public void LastName_GetAndSetShould_WorkProperly(string randomString)
        {
            var obj = new Client();

            obj.LastName = randomString;

            Assert.AreEqual(randomString, obj.LastName);
        }
    }
}
