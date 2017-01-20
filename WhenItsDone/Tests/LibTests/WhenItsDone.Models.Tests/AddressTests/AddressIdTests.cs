using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WhenItsDone.Models.Tests.AddressTests
{
    [TestFixture]
    public class AddressIdTests
    {
        [Test]
        public void Id_ShouldHave_KeyAttribute()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperty("Id")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(KeyAttribute))
                            .Any();

            Assert.IsTrue(result);
        }
    }
}
