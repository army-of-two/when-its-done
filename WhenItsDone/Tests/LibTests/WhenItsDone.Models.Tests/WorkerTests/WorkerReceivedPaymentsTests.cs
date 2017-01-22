using Moq;
using NUnit.Framework;
using System.Collections.Generic;

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
    }
}
