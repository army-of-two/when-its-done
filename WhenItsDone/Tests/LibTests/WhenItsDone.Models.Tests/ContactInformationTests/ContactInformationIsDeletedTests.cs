using NUnit.Framework;

namespace WhenItsDone.Models.Tests.ContactInformationTests
{
    [TestFixture]
    class ContactInformationIsDeletedTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_GetAndSetShould_WorkProperly(bool value)
        {
            var obj = new ContactInformation();

            obj.IsDeleted = value;

            Assert.AreEqual(value, obj.IsDeleted);
        }
    }
}
