using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerIdTests
    {
        [Test]
        public void Id_ShouldHave_KeyAttribute()
        {
            var obj = new Worker();

            var result = obj.GetType()
                            .GetProperty("Id")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(KeyAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [TestCase(6)]
        [TestCase(654353)]
        public void Id_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Worker();

            obj.Id = randomNumber;

            Assert.AreEqual(randomNumber, obj.Id);
        }
    }
}
