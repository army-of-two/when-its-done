using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerPhotoItemsTests
    {
        [Test]
        public void PhotoItems_GetAndSetShould_WorkProperly()
        {
            var mockedCollection = new Mock<ICollection<PhotoItem>>();

            var obj = new Worker();

            obj.PhotoItems = mockedCollection.Object;

            Assert.AreSame(mockedCollection.Object, obj.PhotoItems);
        }
    }
}
