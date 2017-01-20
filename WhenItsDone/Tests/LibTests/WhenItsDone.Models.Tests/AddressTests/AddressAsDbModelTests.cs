using NUnit.Framework;
using System;
using System.Linq;
using WhenItsDone.Models;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.AddressTests
{
    [TestFixture]
    public class AddressAsDbModelTests
    {
        [Test]
        public void AddressClass_ShouldImplement_IDbModelInterface()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetInterfaces()
                            .Any(x => x == typeof(IDbModel));

            Assert.IsTrue(result);
        }
    }
}
