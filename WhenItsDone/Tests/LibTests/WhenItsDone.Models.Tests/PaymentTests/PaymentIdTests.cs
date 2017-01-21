using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WhenItsDone.Models.Tests.PaymentTests
{
    [TestFixture]
    public class PaymentIdTests
    {

        [Test]
        public void Id_ShouldHave_KeyAttribute()
        {
            var obj = new Payment();

            var result = obj.GetType()
                            .GetProperty("Id")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(KeyAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [TestCase(2)]
        [TestCase(7773777)]
        public void Id_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Payment();

            obj.Id = randomNumber;

            Assert.AreEqual(randomNumber, obj.Id);
        }
    }
}
