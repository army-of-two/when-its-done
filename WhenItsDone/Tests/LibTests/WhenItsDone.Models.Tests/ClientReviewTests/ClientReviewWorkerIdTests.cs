using NUnit.Framework;

namespace WhenItsDone.Models.Tests.ClientReviewTests
{
    [TestFixture]
    public class ClientReviewWorkerIdTests
    {
        [TestCase(52342)]
        [TestCase(-4)]
        public void WorkerId_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new ClientReview();

            obj.WorkerId = randomNumber;

            Assert.AreEqual(randomNumber, obj.WorkerId);
        }
    }
}
