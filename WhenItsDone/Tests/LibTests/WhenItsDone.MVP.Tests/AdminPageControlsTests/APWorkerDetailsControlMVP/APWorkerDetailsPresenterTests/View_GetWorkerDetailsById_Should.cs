using Moq;
using NUnit.Framework;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.MVP.AdminPageControls.APWorkerDetailsControlMVP;
using WhenItsDone.MVP.AdminPageControls.EventArguments;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.Tests.AdminPageControlsTests.APWorkerDetailsControlMVP.APWorkerDetailsPresenterTests
{
    [TestFixture]
    public class View_GetWorkerDetailsById_Should
    {
        [Test]
        public void SetProperlyDataFromService_ToViewModel()
        {
            var mockedArgs = new Mock<StringEventArgs>(null);

            var mockedModel = new Mock<APWorkerDetailsControlViewModel>();

            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);

            var mockedResult = new Mock<WorkerDetailInformationDTO>();

            var mockedService = new Mock<IWorkersAsyncService>();
            mockedService.Setup(x => x.GetDetailInfoById(It.IsAny<string>())).Returns(mockedResult.Object);

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object);

            mockedView.Raise(x => x.GetWorkerDetailsById += null, mockedArgs.Object);

            Assert.AreSame(mockedResult.Object, mockedView.Object.Model.Worker);
        }
    }
}
