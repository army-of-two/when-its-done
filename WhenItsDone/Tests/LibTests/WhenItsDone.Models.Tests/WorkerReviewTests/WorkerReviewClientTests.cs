using Moq;
using NUnit.Framework;
using System.Linq;

namespace WhenItsDone.Models.Tests.WorkerReviewTests
{
    [TestFixture]
    public class WorkerReviewClientTests
    {
        [Test]
        public void Client_GetAndSetShould_WorkProperly()
        {
            var mockedWorker = new Mock<Client>();

            var obj = new WorkerReview();

            obj.Client = mockedWorker.Object;

            Assert.AreSame(mockedWorker.Object, obj.Client);
        }

        [Test]
        public void Client_ShouldBe_Virtual()
        {
            var obj = new WorkerReview();

            var result = obj.GetType()
                            .GetProperty("Client")
                            .GetAccessors()
                            .Any(x => x.IsVirtual);

            Assert.IsTrue(result);
        }
    }
}
