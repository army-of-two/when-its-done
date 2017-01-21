using NUnit.Framework;

namespace WhenItsDone.Models.Tests.ClientReviewTests
{
    [TestFixture]
    public class ClientReviewConstructorTests
    {
        [Test]
        public void ClientReview_ShouldHave_ParameterlessConstructor()
        {
            var obj = new ClientReview();

            Assert.IsInstanceOf<ClientReview>(obj);
        }

        [Test]
        public void Constructor_ShouldNotSet_IdParameter()
        {
            var obj = new ClientReview();

            Assert.AreEqual(0, obj.Id);
        }

        [Test]
        public void Constructor_ShouldNotSet_ReviewContentProperty()
        {
            var obj = new ClientReview();

            Assert.AreEqual(null, obj.ReviewContent);
        }

        [Test]
        public void Constructor_ShouldNotSet_ScoreProperty()
        {
            var obj = new ClientReview();

            Assert.AreEqual(0, obj.Score);
        }

        [Test]
        public void Constuctor_ShouldNotSet_WorkerIdProperty()
        {
            var obj = new ClientReview();

            Assert.AreEqual(0, obj.WorkerId);
        }

        [Test]
        public void Constructor_ShouldNotSet_WorkerProperty()
        {
            var obj = new ClientReview();

            Assert.AreEqual(null, obj.Worker);
        }

        [Test]
        public void Constructor_ShouldNotSet_IsDeletedProperty()
        {
            var obj = new ClientReview();

            Assert.IsFalse(obj.IsDeleted);
        }
    }
}
