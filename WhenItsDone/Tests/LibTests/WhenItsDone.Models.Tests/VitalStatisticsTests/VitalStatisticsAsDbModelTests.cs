using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.VitalStatisticsTests
{
    [TestFixture]
    public class VitalStatisticsAsDbModelTests
    {
        [Test]
        public void VitalStatistics_ShouldImplement_IDbModelInteface()
        {
            var obj = new VitalStatistics();

            var result = obj.GetType()
                            .GetInterfaces()
                            .Where(x => x == typeof(IDbModel))
                            .Any();

            Assert.IsTrue(result);
        }
    }
}
