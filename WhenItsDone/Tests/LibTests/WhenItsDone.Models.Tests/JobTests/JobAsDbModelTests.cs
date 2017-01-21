using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.JobTests
{
    [TestFixture]
    class JobAsDbModelTests
    {
        [Test]
        public void Client_ShouldImplement_IDbModelInterface()
        {
            var obj = new Job();

            var result = obj.GetType()
                            .GetInterfaces()
                            .Any(x => x == typeof(IDbModel));

            Assert.IsTrue(result);
        }
    }
}
