using NUnit.Framework;

namespace WhenItsDone.Models.Tests.WorkerReviewTests
{
    [TestFixture]
    public class WorkerReviewConstructorTests
    {
        [Test]
        public void WorkerReview_ShouldHave_ParameterlessConstructor()
        {
            var obj = new WorkerReview();

            Assert.IsInstanceOf<WorkerReview>(obj);
        }

        [Test]
        public void Constructor_ShouldNotSet_IdParameter()
        {
            var obj = new WorkerReview();

            Assert.AreEqual(0, obj.Id);
        }

        [Test]
        public void Constructor_ShouldNotSet_ReviewContentProperty()
        {
            var obj = new WorkerReview();

            Assert.AreEqual(null, obj.ReviewContent);
        }

        [Test]
        public void Constructor_ShouldNotSet_ScoreProperty()
        {
            var obj = new WorkerReview();

            Assert.AreEqual(0, obj.Score);
        }

        [Test]
        public void Constuctor_ShouldNotSet_WorkerIdProperty()
        {
            var obj = new WorkerReview();

            Assert.AreEqual(0, obj.ClientId);
        }

        [Test]
        public void Constructor_ShouldNotSet_WorkerProperty()
        {
            var obj = new WorkerReview();

            Assert.AreEqual(null, obj.Client);
        }

        [Test]
        public void Constructor_ShouldNotSet_IsDeletedProperty()
        {
            var obj = new WorkerReview();

            Assert.IsFalse(obj.IsDeleted);
        }
    }
}
