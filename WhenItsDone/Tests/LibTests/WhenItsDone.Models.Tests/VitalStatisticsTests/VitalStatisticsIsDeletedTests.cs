using NUnit.Framework;

namespace WhenItsDone.Models.Tests.VitalStatisticsTests
{
    [TestFixture]
    public class VitalStatisticsIsDeletedTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_GetAndSetShould_WorkProperly(bool value)
        {
            var obj = new VitalStatistics();

            obj.IsDeleted = value;

            Assert.AreEqual(value, obj.IsDeleted);
        }
    }
}
