using NUnit.Framework;
using WhenItsDone.MVP.AdminPageControls.EventArguments;

namespace WhenItsDone.MVP.Tests.AdminPageControlsTests.EventArgumentsTests.StringEventArgsTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase("4dqwdwq")]
        [TestCase("vvv&^&^#")]
        [TestCase(">>#(*#@..")]
        [TestCase("323 3213 33")]
        public void SetPassedParameter_ToProperty(string randomString)
        {
            var obj = new StringEventArgs(randomString);

            Assert.AreEqual(randomString, obj.StringParameter);
        }

        [Test]
        public void SetPassedParameter_ToProperty_WhenArgumentIsNull()
        {
            var obj = new StringEventArgs(null);

            Assert.IsNull(obj.StringParameter);
        }

        [Test]
        public void SetPassedParameter_ToProperty_WhenArgumentIsEmptyString()
        {
            var obj = new StringEventArgs(string.Empty);

            Assert.AreEqual(string.Empty, obj.StringParameter);
        }
    }
}
