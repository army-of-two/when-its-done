using NUnit.Framework;

namespace WhenItsDone.Models.Tests.VideoItemTests
{
    [TestFixture]
    public class VideoItemIsDeletedTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_GetAndSetShould_WorkProperly(bool value)
        {
            var obj = new VideoItem();

            obj.IsDeleted = value;

            Assert.AreEqual(value, obj.IsDeleted);
        }
    }
}
