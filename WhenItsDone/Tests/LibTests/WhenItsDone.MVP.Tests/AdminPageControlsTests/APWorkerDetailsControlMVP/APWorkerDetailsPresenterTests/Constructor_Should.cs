using Moq;
using NUnit.Framework;
using System.Reflection;
using WhenItsDone.MVP.AdminPageControls.APWorkerDetailsControlMVP;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.Tests.AdminPageControlsTests.APWorkerDetailsControlMVP.APWorkerDetailsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullExceptionWithProperMessage_WhenServiceIsNull()
        {
            var mockedView = new Mock<IAPWorkerDetailsControlView>();

            Assert.That(() => new APWorkerDetailsPresenter(mockedView.Object, null),
                                Throws.ArgumentNullException.With.Message.Contains("workersService"));
        }

        [Test]
        public void SetService_ToField_WhenArgumentsAre_Valid()
        {
            var mockedView = new Mock<IAPWorkerDetailsControlView>();

            var mockedService = new Mock<IWorkersAsyncService>();

            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var field = typeof(APWorkerDetailsPresenter).GetField("workerService", flags);

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object);

            var result = field.GetValue(obj);

            Assert.AreSame(mockedService.Object, result);
        }

        [Test]
        public void CallBaseConstructor_WithSameView()
        {
            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object);

            Assert.AreSame(mockedView.Object, obj.View);
        }
    }
}
