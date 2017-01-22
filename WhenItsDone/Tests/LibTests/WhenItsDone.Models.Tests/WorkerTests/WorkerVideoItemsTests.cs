using Moq;
using NUnit.Framework;
using System.Collections.Generic;

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
    }
}
