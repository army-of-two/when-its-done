using NUnit.Framework;

namespace WhenItsDone.Models.Tests.VitalStatisticsTests
{
    [TestFixture]
    public class VitalStatisticsIdTests
    {
        [TestCase(5)]
        [TestCase(7887)]
        public void Id_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new VitalStatistics();

            obj.Id = randomNumber;

            Assert.AreEqual(randomNumber, obj.Id);
        }
    }
}
