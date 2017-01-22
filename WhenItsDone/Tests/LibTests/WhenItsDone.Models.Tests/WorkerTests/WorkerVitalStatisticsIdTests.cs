using NUnit.Framework;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerVitalStatisticsIdTests
    {
        [TestCase(123231)]
        [TestCase(-7)]
        public void VitalStatisticsId_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Worker();

            obj.VitalStatisticsId = randomNumber;

            Assert.AreEqual(randomNumber, obj.VitalStatisticsId);
        }
    }
}
