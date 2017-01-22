using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WhenItsDone.Models.Tests.WorkerReviewTests
{
    [TestFixture]
    public class WorkerReviewIdTests
    {
        [Test]
        public void Id_ShouldHave_KeyAttribute()
        {
            var obj = new WorkerReview();

            var result = obj.GetType()
                            .GetProperty("Id")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(KeyAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [TestCase(60)]
        [TestCase(64324234)]
        public void Id_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new WorkerReview();

            obj.Id = randomNumber;

            Assert.AreEqual(randomNumber, obj.Id);
        }
    }
}
