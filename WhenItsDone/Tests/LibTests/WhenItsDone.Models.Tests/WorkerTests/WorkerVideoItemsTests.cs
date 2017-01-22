using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerVideoItemsTests
    {
        [Test]
        public void VideoItems_GetAndSetShould_WorkProperly()
        {
            var mockedCollection = new Mock<ICollection<VideoItem>>();

            var obj = new Worker();

            obj.VideoItems = mockedCollection.Object;

            Assert.AreSame(mockedCollection.Object, obj.VideoItems);
        }

        [Test]
        public void VideoItems_ShouldBe_Virtual()
        {
            var obj = new Worker();

            var result = obj.GetType()
                            .GetProperty("VideoItems")
                            .GetAccessors()
                            .Where(x => x.IsVirtual)
                            .Any();

            Assert.IsTrue(result);
        }
    }
}
