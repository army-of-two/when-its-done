using Moq;
using NUnit.Framework;
using System.Linq;

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

        [Test]
        public void Worker_ShouldBe_Virtual()
        {
            var obj = new Job();

            var result = obj.GetType()
                            .GetProperty("Worker")
                            .GetAccessors()
                            .Any(x => x.IsVirtual);

            Assert.IsTrue(result);
        }
    }
}
