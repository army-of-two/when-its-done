using NUnit.Framework;

namespace WhenItsDone.Models.Tests.JobTests
{
    [TestFixture]
    public class JobWorkerIdTests
    {
        [TestCase(5454353)]
        [TestCase(3)]
        public void WorkerId_GetAndSetShould_workProperly(int randomNumber)
        {
            var obj = new Job();

            obj.WorkerId = randomNumber;

            Assert.AreEqual(randomNumber, obj.WorkerId);
        }
    }
}
