using NUnit.Framework;
using System;

namespace WhenItsDone.Models.Tests.JobTests
{
    [TestFixture]
    public class JobScheduledTimeTests
    {
        [TestCase(1000, 4, 4)]
        [TestCase(2013, 12, 2)]
        [TestCase(1998, 1, 21)]
        public void ScheduledTime_GetAndSetShould_WorkProperly(int year, int month, int day)
        {
            var expected = new DateTime(year, month, day);

            var obj = new Job();

            obj.ScheduledTime = expected;

            Assert.AreEqual(expected, obj.ScheduledTime);
        }
    }
}
