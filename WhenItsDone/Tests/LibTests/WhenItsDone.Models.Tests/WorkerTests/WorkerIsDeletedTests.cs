using NUnit.Framework;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerIsDeletedTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_GetAndSetShould_WorkProperly(bool value)
        {
            var obj = new Worker();

            obj.IsDeleted = value;

            Assert.AreEqual(value, obj.IsDeleted);
        }
    }
}
