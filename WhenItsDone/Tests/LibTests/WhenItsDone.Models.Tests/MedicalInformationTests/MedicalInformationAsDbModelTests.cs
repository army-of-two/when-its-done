using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.MedicalInformationTests
{
    [TestFixture]
    public class MedicalInformationAsDbModelTests
    {
        [Test]
        public void MedicalInformation_ShouldImplement_IDbModelInteface()
        {
            var obj = new MedicalInformation();

            var result = obj.GetType()
                            .GetInterfaces()
                            .Where(x => x == typeof(IDbModel))
                            .Any();

            Assert.IsTrue(result);
        }
    }
}
