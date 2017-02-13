using Moq;
using NUnit.Framework;
using System.Reflection;
using WhenItsDone.MVP.AdminPageControls.APWorkersControlMVP;
using WhenItsDone.Services.Contracts;

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

        [Test]
        public void Set_WorkerService_In_ServiceField()
        {
            var mockedView = new Mock<IAPWorkersControlView>();

            var mockedService = new Mock<IWorkersAsyncService>();

            var obj = new APWorkersControlPresenter(mockedView.Object, mockedService.Object);

            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var serviceField = typeof(APWorkersControlPresenter).GetField("workersService", flags);
            var result = serviceField.GetValue(obj);

            Assert.AreSame(mockedService.Object, result);
        }

        [Test]
        public void Call_Base_With_Same_View()
        {
            var mockedView = new Mock<IAPWorkersControlView>();

            var mockedService = new Mock<IWorkersAsyncService>();

            var obj = new APWorkersControlPresenter(mockedView.Object, mockedService.Object);

            Assert.AreSame(mockedView.Object, obj.View);
        }


    }
}
