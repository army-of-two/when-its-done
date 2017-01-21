using NUnit.Framework;
using System;

namespace WhenItsDone.Models.Tests.JobTests
{
    [TestFixture]
    public class JobConstructorTests
    {
        [Test]
        public void JobClass_ShouldHave_ParameterlessConstructor()
        {
            var obj = new Job();

            Assert.IsInstanceOf<Job>(obj);
        }

        [Test]
        public void Constructor_ShouldNotSet_IdProperty()
        {
            var obj = new Job();

            Assert.AreEqual(0, obj.Id);
        }

        [Test]
        public void Constructor_ShouldNotSet_ScheduledTimeProperty()
        {
            var expected = default(DateTime);

            var obj = new Job();

            Assert.AreEqual(expected, obj.ScheduledTime);
        }

        [Test]
        public void Constructor_ShouldNotSet_PriceProperty()
        {
            var obj = new Job();

            Assert.AreEqual(0, obj.Price);
        }

        [Test]
        public void Constructor_ShouldNotSet_WorkerIdProperty()
        {
            var obj = new Job();

            Assert.AreEqual(0, obj.WorkerId);
        }

        [Test]
        public void Constructor_ShouldNotSet_WorkerProperty()
        {
            var obj = new Job();

            Assert.AreEqual(null, obj.Worker);
        }

        [Test]
        public void Constructor_ShouldNotSet_ClientIdProperty()
        {
            var obj = new Job();

            Assert.AreEqual(0, obj.ClientId);
        }

        [Test]
        public void Constructor_ShouldNotSet_ClientProperty()
        {
            var obj = new Job();

            Assert.AreEqual(null, obj.Client);
        }

        [Test]
        public void Constructor_ShouldNotSet_IsCompletedProperty()
        {
            var obj = new Job();

            Assert.AreEqual(false, obj.IsCompleted);
        }

        [Test]
        public void Constructor_ShouldNotSet_IsDeletedProperty()
        {
            var obj = new Job();

            Assert.AreEqual(false, obj.IsDeleted);
        }
    }
}
