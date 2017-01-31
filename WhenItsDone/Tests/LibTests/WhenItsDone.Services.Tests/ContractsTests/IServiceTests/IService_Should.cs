using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using WhenItsDone.Services.AssemblyId;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services.Tests.ContractsTests.IServiceTests
{
    [TestFixture]
    public class IService_Should
    {
        [Test]
        public void Be_Implemented_ByAllServices()
        {
            Type t = typeof(IServicesAssemblyId);

            var result = Assembly.GetAssembly(t)
                                    .GetTypes()
                                    .Where(x => x.IsClass && !x.IsAbstract && x.Name.IndexOf("Service") >= 0)
                                    .All(x => x.GetInterfaces().Contains(typeof(IService)));

            Assert.IsTrue(result);
        }
    }
}
