using System.Reflection;

using NUnit.Framework;

using WhenItsDone.Data.AssemblyId;

namespace WhenItsDone.Data.Tests.AssemblyIdTests
{
    [TestFixture]
    public class Assembly_Should
    {
        [Test]
        public void Assembly_ShouldContainIMvpAssemblyId()
        {
            var typeIMvpAssemblyId = typeof(IDataAssemblyId);
            var foundAssembly = Assembly.GetAssembly(typeIMvpAssemblyId);

            Assert.That(foundAssembly.FullName, Is.Not.Null.And.Contains("WhenItsDone.Data"));
        }
    }
}
