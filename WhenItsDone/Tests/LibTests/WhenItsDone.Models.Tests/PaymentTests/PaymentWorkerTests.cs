using Moq;
using NUnit.Framework;

namespace WhenItsDone.Models.Tests.PaymentTests
{
    class PaymentWorkerTests
    {
        [Test]
        public void Worker_GetAndSetShould_WorkProperly()
        {
            var mockedWorker = new Mock<Worker>();

            var obj = new Payment();

            obj.Worker = mockedWorker.Object;

            Assert.AreSame(mockedWorker.Object, obj.Worker);
        }
    }
}
