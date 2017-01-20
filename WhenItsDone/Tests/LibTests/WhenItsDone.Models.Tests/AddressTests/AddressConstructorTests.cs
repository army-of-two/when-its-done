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
    }
}
