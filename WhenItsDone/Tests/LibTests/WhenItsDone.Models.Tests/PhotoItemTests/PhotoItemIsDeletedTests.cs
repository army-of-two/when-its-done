using NUnit.Framework;

namespace WhenItsDone.Models.Tests.PhotoItemTests
{
    [TestFixture]
    public class PhotoItemIsDeletedTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_GetAndSetShould_WorkProperly(bool value)
        {
            var obj = new PhotoItem();

            obj.IsDeleted = value;

            Assert.AreEqual(value, obj.IsDeleted);
        }
    }
}
