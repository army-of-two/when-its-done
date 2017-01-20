using NUnit.Framework;
using System.Linq;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.ClientReviewTests
{
    [TestFixture]
    public class ClientReviewAsDbModel
    {
        [Test]
        public void ClientReviewClass_ShouldImplement_IDbModelInterface()
        {
            var obj = new ClientReview();

            var result = obj.GetType()
                            .GetInterfaces()
                            .Where(x => x == typeof(IDbModel))
                            .Any();

            Assert.IsTrue(result);
        }
    }
}
