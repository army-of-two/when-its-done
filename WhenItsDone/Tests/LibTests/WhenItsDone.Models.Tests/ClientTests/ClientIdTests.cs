using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WhenItsDone.Models.Tests.ClientTests
{
    [TestFixture]
    public class ClientIdTests
    {
        [Test]
        public void Id_ShouldHave_KeyAttribute()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("Id")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(KeyAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [TestCase(90)]
        [TestCase(4993993)]
        public void Id_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Client();

            obj.Id = randomNumber;

            Assert.AreEqual(randomNumber, obj.Id);
        }
    }
}
