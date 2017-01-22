using Moq;
using NUnit.Framework;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerVitalStatisticsTests
    {
        [Test]
        public void VitalStatistics_GetAndSetShould_WorkProperly()
        {
            var mockedVS = new Mock<VitalStatistics>();

            var obj = new Worker();

            obj.VitalStatistics = mockedVS.Object;

            Assert.AreSame(mockedVS.Object, obj.VitalStatistics);
        }
    }
}
