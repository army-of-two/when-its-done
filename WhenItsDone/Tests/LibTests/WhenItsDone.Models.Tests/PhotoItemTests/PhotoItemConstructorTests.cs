using NUnit.Framework;

namespace WhenItsDone.Models.Tests.PhotoItemTests
{
    [TestFixture]
    public class PhotoItemConstructorTests
    {
        [Test]
        public void PhotoItemClass_Shouldhave_ParameterlessConstructor()
        {
            var obj = new PhotoItem();

            Assert.IsInstanceOf<PhotoItem>(obj);
        }

        [Test]
        public void Constructor_ShouldNotSet_IdProperty()
        {
            var obj = new PhotoItem();

            Assert.AreEqual(0, obj.Id);
        }

        [Test]
        public void Constructor_ShouldNotSet_UrlProperty()
        {
            var obj = new PhotoItem();

            Assert.AreEqual(null, obj.Url);
        }

        [Test]
        public void Constructor_ShouldNotSet_IsDeletedProperty()
        {
            var obj = new PhotoItem();

            Assert.AreEqual(false, obj.IsDeleted);
        }
    }
}
