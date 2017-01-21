using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhenItsDone.Models.Tests.ReceivedPaymentTests
{
    [TestFixture]
    public class ReceivedPaymentClientIdTests
    {
        [TestCase(46)]
        [TestCase(1855)]
        public void ClientId_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new ReceivedPayment();

            obj.ClientId = randomNumber;

            Assert.AreEqual(randomNumber, obj.ClientId);
        }
    }
}

