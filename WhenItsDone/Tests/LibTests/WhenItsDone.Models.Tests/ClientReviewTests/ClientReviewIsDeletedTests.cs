using NUnit.Framework;

namespace WhenItsDone.Models.Tests.ClientReviewTests
{
    [TestFixture]
    public class ClientReviewIsDeletedTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_GetAndSetShould_WorkProperly(bool value)
        {
            var obj = new ClientReview();

            obj.IsDeleted = value;

            Assert.AreEqual(value, obj.IsDeleted);
        }
    }
}
