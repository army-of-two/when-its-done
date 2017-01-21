using NUnit.Framework;

namespace WhenItsDone.Models.Tests.ContactInformationTests
{
    [TestFixture]
    public class ContactInformationConstructorTests
    {
        [Test]
        public void ContactInformationClass_ShouldHave_ParameterlessConstructor()
        {
            var obj = new ContactInformation();

            Assert.IsInstanceOf<ContactInformation>(obj);
        }

        [Test]
        public void Constructor_ShouldNotSet_IdProperty()
        {
            var obj = new ContactInformation();

            Assert.AreEqual(0, obj.Id);
        }

        [Test]
        public void Constructor_ShouldNotSet_AddressIdProperty()
        {
            var obj = new ContactInformation();

            Assert.AreEqual(0, obj.AddressId);
        }

        [Test]
        public void Constructor_ShouldNotSet_AddressProperty()
        {
            var obj = new ContactInformation();

            Assert.AreEqual(null, obj.Address);
        }

        [Test]
        public void Constructor_ShouldNotSet_EmailProperty()
        {
            var obj = new ContactInformation();

            Assert.AreEqual(null, obj.Email);
        }

        [Test]
        public void Constructor_ShouldNotSet_PhoneNumberProperty()
        {
            var obj = new ContactInformation();

            Assert.AreEqual(null, obj.PhoneNumber);
        }

        [Test]
        public void Constructor_ShouldNotSet_IsDeletedProperty()
        {
            var obj = new ContactInformation();

            Assert.AreEqual(false, obj.IsDeleted);
        }
    }
}
