using NUnit.Framework;

namespace WhenItsDone.Models.Tests.PhotoItemTests
{
    [TestFixture]
    public class PhotoItemUrlTests
    {
        [TestCase("Merry Christmas")]
        [TestCase("abv.bg/bg/abv/default.aspx")]
        public void Url_GetAndSetShould_WorkProperly(string randomString)
        {
            var obj = new PhotoItem();

            obj.Url = randomString;

            Assert.AreEqual(randomString, obj.Url);
        }
    }
}
