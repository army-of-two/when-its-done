using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerReceivedPaymentsTests
    {
        [Test]
        public void ReceivedPayments_GetAndSetShould_WorkProperly()
        {
            var mockedCollection = new Mock<ICollection<ReceivedPayment>>();

            var obj = new Worker();

            obj.ReceivedPayments = mockedCollection.Object;

            Assert.AreSame(mockedCollection.Object, obj.ReceivedPayments);
        }

        [Test]
        public void ReceivedPayments_ShouldBe_Virtual()
        {
            var obj = new Worker();

            var result = obj.GetType()
                            .GetProperty("ReceivedPayments")
                            .GetAccessors()
                            .Where(x => x.IsVirtual)
                            .Any();

            Assert.IsTrue(result);
        }
    }
}
