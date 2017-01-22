using NUnit.Framework;

namespace WhenItsDone.Models.Tests.ClientReviewTests
{
    [TestFixture]
    public class WorkerReviewClientIdTests
    {
        [TestCase(542)]
        [TestCase(-44444444)]
        public void ClientId_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new WorkerReview();

            obj.ClientId = randomNumber;

            Assert.AreEqual(randomNumber, obj.ClientId);
        }
    }
}
