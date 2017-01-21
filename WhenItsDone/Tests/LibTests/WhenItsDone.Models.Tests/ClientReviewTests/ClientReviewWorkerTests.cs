using Moq;
using NUnit.Framework;
using System.Linq;

namespace WhenItsDone.Models.Tests.ClientReviewTests
{
    [TestFixture]
    public class ClientReviewWorkerTests
    {
        [Test]
        public void Worker_GetAndSetShould_WorkProperly()
        {
            var mockedWorker = new Mock<Worker>();

            var obj = new ClientReview();

            obj.Worker = mockedWorker.Object;

            Assert.AreSame(mockedWorker.Object, obj.Worker);
        }

        [Test]
        public void Worker_ShouldBe_Virtual()
        {
            var obj = new ClientReview();

            var result = obj.GetType()
                            .GetProperty("Worker")
                            .GetAccessors()
                            .Any(x => x.IsVirtual);

            Assert.IsTrue(result);
                
        }
    }
}
