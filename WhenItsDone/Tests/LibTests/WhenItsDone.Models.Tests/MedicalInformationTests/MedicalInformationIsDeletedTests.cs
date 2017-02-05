using NUnit.Framework;

namespace WhenItsDone.Models.Tests.MedicalInformationTests
{
    [TestFixture]
    public class MedicalInformationIsDeletedTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_GetAndSetShould_WorkProperly(bool value)
        {
            var obj = new MedicalInformation();

            obj.IsDeleted = value;

            Assert.AreEqual(value, obj.IsDeleted);
        }
    }
}
