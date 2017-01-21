using NUnit.Framework;

namespace WhenItsDone.Models.Tests.JobTests
{
    [TestFixture]
    public class JobIsCompletedTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsCompleted_GetAndSetShould_WorkProperly(bool value)
        {
            var obj = new Job();

            obj.IsCompleted = value;

            Assert.AreEqual(value, obj.IsCompleted);
        }
    }
}
