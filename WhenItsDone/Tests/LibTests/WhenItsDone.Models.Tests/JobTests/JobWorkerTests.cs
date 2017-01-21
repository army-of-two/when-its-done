using Moq;
using NUnit.Framework;

namespace WhenItsDone.Models.Tests.JobTests
{
    [TestFixture]
    public class JobWorkerTests
    {
        [Test]
        public void Worker_GetAndSetShould_WorkProperly()
        {
            var mockedWorker = new Mock<Worker>();

            var obj = new Job();

            obj.Worker = mockedWorker.Object;

            Assert.AreSame(mockedWorker.Object, obj.Worker);
        }
    }
}
