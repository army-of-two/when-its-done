using NUnit.Framework;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerIsAvailableTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsAvailable_GetAndSetShould_WorkProperly(bool value)
        {
            var obj = new Worker();

            obj.IsAvailable = value;

            Assert.AreEqual(value, obj.IsAvailable);
        }
    }
}
