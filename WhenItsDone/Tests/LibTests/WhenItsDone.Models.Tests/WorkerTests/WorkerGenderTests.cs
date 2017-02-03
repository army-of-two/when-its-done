using NUnit.Framework;
using WhenItsDone.Common.Enums;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerGenderTests
    {
        [TestCase(GenderType.Undefined)]
        [TestCase(GenderType.Female)]
        [TestCase(GenderType.Male)]
        public void Gender_GetAndSetShould_WorkProperly(GenderType randomGender)
        {
            var obj = new Worker();

            obj.Gender = randomGender;

            Assert.AreEqual(randomGender, obj.Gender);
        }
    }
}
