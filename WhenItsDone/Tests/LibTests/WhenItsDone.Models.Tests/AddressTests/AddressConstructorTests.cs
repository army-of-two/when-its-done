using NUnit.Framework;

namespace WhenItsDone.Models.Tests.AddressTests
{
    [TestFixture]
    public class AddressConstructorTests
    {
        [Test]
        public void Address_ShouldHave_ParameterlessConstructor()
        {
            var obj = new Address();

            Assert.IsInstanceOf<Address>(obj);
        }

        [Test]
        public void Constructor_ShouldNotSet_IdProperty()
        {
            var obj = new Address();

            Assert.AreEqual(0, obj.Id);
        }

        [Test]
        public void Constructor_ShouldNotSet_CountryProperty()
        {
            var obj = new Address();

            Assert.AreEqual(null, obj.Country);
        }

        [Test]
        public void Constructor_ShouldNotSet_CityProperty()
        {
            var obj = new Address();

            Assert.AreEqual(null, obj.City);
        }

        [Test]
        public void Constructor_ShouldNotSet_StreetProperty()
        {
            var obj = new Address();

            Assert.AreEqual(null, obj.Street);
        }

        [Test]
        public void Constructor_ShouldNotSet_IsDeletedProperty()
        {
            var obj = new Address();

            Assert.IsFalse(obj.IsDeleted);
        }
    }
}
