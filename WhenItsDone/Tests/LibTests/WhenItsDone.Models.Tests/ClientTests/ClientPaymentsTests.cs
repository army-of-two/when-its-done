using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WhenItsDone.Models.Tests.ClientTests
{
    [TestFixture]
    public class ClientPaymentsTests
    {
        [Test]
        public void Payments_GetAndSetShould_WorkProperly()
        {
            var mockedPayments = new Mock<ICollection<Payment>>();

            var obj = new Client();

            obj.Payments = mockedPayments.Object;

            Assert.AreSame(mockedPayments.Object, obj.Payments);
        }

        [Test]
        public void Payments_ShouldBe_Virtual()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("Payments")
                            .GetAccessors()
                            .Any(x => x.IsVirtual);

            Assert.IsTrue(result);
        }
    }
}
