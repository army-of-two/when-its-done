using System.Reflection;

using NUnit.Framework;

using WhenItsDone.Services.AssemblyId;

namespace WhenItsDone.Services.Tests.AssemblyIdTests
{
    [TestFixture]
    public class Assembly_Should
    {
        [Test]
        public void Assembly_ShouldContainIMvpAssemblyId()
        {
            var typeIMvpAssemblyId = typeof(IServicesAssemblyId);
            var foundAssembly = Assembly.GetAssembly(typeIMvpAssemblyId);

            Assert.That(foundAssembly.FullName, Is.Not.Null.And.Contains("WhenItsDone.Services"));
        }
    }
}
