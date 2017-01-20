using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.ClientTests
{
    [TestFixture]
    public class ClientAsDbModelTests
    {
        [Test]
        public void Client_ShouldImplement_IDbModelInterface()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetInterfaces()
                            .Any(x => x == typeof(IDbModel));

            Assert.IsTrue(result);
        }
    }
}
