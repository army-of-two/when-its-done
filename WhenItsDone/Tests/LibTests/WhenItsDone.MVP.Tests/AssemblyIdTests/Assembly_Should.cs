using System.Reflection;

using NUnit.Framework;

using WhenItsDone.MVP.AssemblyId;

namespace WhenItsDone.MVP.Tests.AssemblyIdTests
{
    [TestFixture]
    public class Assembly_Should
    {
        [Test]
        public void Assembly_ShouldContainIMvpAssemblyId()
        {
            var typeIMvpAssemblyId = typeof(IMvpAssemblyId);
            var foundAssembly = Assembly.GetAssembly(typeIMvpAssemblyId);

            Assert.That(foundAssembly.FullName, Is.Not.Null.And.Contains("WhenItsDone.MVP"));
        }
    }
}
