using System.Data.Entity;

using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using System.Reflection;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Tests.WhenItsDoneDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldCreateAValidInstanceOfDbContext()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            Assert.That(whenItsDoneDbContext, Is.InstanceOf<DbContext>());
        }

        [Test]
        public void ShouldCreateAValidInstanceOfIWhenItsDoneDbContext()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            Assert.That(whenItsDoneDbContext, Is.InstanceOf<IWhenItsDoneDbContext>());
        }

        [Test]
        public void ShouldCreateAValidInstance_WithAddressesProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Addresses";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var addressesProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(addressesProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithAddressVirtualProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Addresses";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var addressesProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(addressesProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithAddressVirtualProperty_OfTypeIDbSetAddresses()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Addresses";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var addressesProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(addressesProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Address>)));
        }
    }
}
