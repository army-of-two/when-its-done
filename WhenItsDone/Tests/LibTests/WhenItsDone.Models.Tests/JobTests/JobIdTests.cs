using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WhenItsDone.Models.Tests.JobTests
{
    [TestFixture]
    public class JobIdTests
    {

        [Test]
        public void Id_ShouldHave_KeyAttribute()
        {
            var obj = new Job();

            var result = obj.GetType()
                            .GetProperty("Id")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(KeyAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [TestCase(66444555)]
        [TestCase(2)]
        public void Id_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Job();

            obj.Id = randomNumber;

            Assert.AreEqual(randomNumber, obj.Id);
        }
    }
}
