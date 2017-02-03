using NUnit.Framework;
using WhenItsDone.Common.Enums;

namespace WhenItsDone.Models.Tests.ClientTests
{
    [TestFixture]
    public class ClientGenderTests
    {
        [TestCase(GenderType.Undefined)]
        [TestCase(GenderType.Female)]
        [TestCase(GenderType.Male)]
        public void Gender_GetAndSetShould_WorkProperly(GenderType randomGender)
        {
            var obj = new Client();

            obj.Gender = randomGender;

            Assert.AreEqual(randomGender, obj.Gender);
        }
    }
}
