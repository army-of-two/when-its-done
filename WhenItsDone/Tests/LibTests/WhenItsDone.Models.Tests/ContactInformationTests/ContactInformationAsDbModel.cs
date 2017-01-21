using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.ContactInformationTests
{
    [TestFixture]
    public class ContactInformationAsDbModel
    {
        [Test]
        public void ContactInformationClass_ShouldImplement_IDbModelInterface()
        {
            var obj = new ContactInformation();

            var result = obj.GetType()
                            .GetInterfaces()
                            .Any(x => x == typeof(IDbModel));

            Assert.IsTrue(result);
        }
    }
}
