using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.ContactInformationTests
{
    [TestFixture]
    public class ContactInformationPhoneNumberTests
    {
        [Test]
        public void PhoneNumber_ShouldHave_MinLengthAttribute()
        {
            var obj = new ContactInformation();

            var result = obj.GetType()
                            .GetProperty("PhoneNumber")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void PhoneNumber_ShouldHave_RightValueFor_MinLengthAttribute()
        {
            var obj = new ContactInformation();

            var result = obj.GetType()
                            .GetProperty("PhoneNumber")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Select(x => (MinLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.PhoneMinLength, result.Length);
        }

        [Test]
        public void PhoneNumber_ShouldHave_MaxLengthAttribute()
        {
            var obj = new ContactInformation();

            var result = obj.GetType()
                            .GetProperty("PhoneNumber")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void PhoneNumber_ShouldHave_RightValueFor_MaxLengthAttribute()
        {
            var obj = new ContactInformation();

            var result = obj.GetType()
                            .GetProperty("PhoneNumber")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Select(x => (MaxLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.PhoneMaxLength, result.Length);
        }

        [Test]
        public void PhoneNumber_ShouldHave_RegularExpressionhAttribute()
        {
            var obj = new ContactInformation();

            var result = obj.GetType()
                            .GetProperty("PhoneNumber")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RegularExpressionAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void PhoneNumber_ShouldHave_RightValueFor_RegularExpressionAttribute()
        {
            var obj = new ContactInformation();

            var result = obj.GetType()
                            .GetProperty("PhoneNumber")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RegularExpressionAttribute))
                            .Select(x => (RegularExpressionAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(RegexConstants.Phone, result.Pattern);
        }
    }
}
