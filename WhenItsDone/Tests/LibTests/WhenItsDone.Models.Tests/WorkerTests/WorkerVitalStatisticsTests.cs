using Moq;
using NUnit.Framework;
using System.Linq;

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

        [Test]
        public void VitalStatistics_ShouldBe_Virtual()
        {
            var obj = new Worker();

            var result = obj.GetType()
                            .GetProperty("VitalStatistics")
                            .GetAccessors()
                            .Where(x => x.IsVirtual)
                            .Any();

            Assert.IsTrue(result);
        }
    }
}
