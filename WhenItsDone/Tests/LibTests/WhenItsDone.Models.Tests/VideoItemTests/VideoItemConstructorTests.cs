using NUnit.Framework;

namespace WhenItsDone.Models.Tests.VideoItemTests
{
    [TestFixture]
    public class VideoItemConstructorTests
    {
        [Test]
        public void VideoItemClass_Shouldhave_ParameterlessConstructor()
        {
            var obj = new VideoItem();

            Assert.IsInstanceOf<VideoItem>(obj);
        }

        [Test]
        public void Constructor_ShouldNotSet_IdProperty()
        {
            var obj = new VideoItem();

            Assert.AreEqual(0, obj.Id);
        }

        [Test]
        public void Constructor_ShouldNotSet_UrlProperty()
        {
            var obj = new VideoItem();

            Assert.AreEqual(null, obj.Url);
        }

        [Test]
        public void Constructor_ShouldNotSet_IsDeletedProperty()
        {
            var obj = new VideoItem();

            Assert.AreEqual(false, obj.IsDeleted);
        }
    }
}
