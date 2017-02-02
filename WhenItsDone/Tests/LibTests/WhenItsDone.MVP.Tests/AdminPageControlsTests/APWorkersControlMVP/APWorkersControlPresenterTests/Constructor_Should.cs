using Moq;
using NUnit.Framework;
using WhenItsDone.MVP.AdminPageControls.APWorkersControlMVP;

namespace WhenItsDone.MVP.Tests.AdminPageControlsTests.APWorkersControlMVP.APWorkersControlPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNulLException_WithProperMessage_When_Service_IsNull()
        {
            var mockedView = new Mock<IAPWorkersControlView>();
            
            Assert.That(() => new APWorkersControlPresenter(mockedView.Object, null),
                            Throws.ArgumentNullException.With.Message.Contains("WorkersService"));
        }
    }
}
