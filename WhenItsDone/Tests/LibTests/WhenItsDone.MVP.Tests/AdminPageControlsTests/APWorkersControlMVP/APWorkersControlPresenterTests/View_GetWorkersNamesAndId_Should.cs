using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.MVP.AdminPageControls.APWorkersControlMVP;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.Tests.AdminPageControlsTests.APWorkersControlMVP.APWorkersControlPresenterTests
{
    [TestFixture]
    public class View_GetWorkersNamesAndId_Should
    {
        // Test will fail if constructor didnt subscribe too 
        [Test]
        public void Set_DataToViewModel_WhenViewFireTheEvent()
        {
            var mockedCollection = new Mock<IEnumerable<WorkerNamesIdDTO>>();

            var mockedModel = new Mock<APWorkersControlViewModel>();

            var mockedView = new Mock<IAPWorkersControlView>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);

            var mockedService = new Mock<IWorkersAsyncService>();
            mockedService.Setup(x => x.GetWorkersNamesAndId()).Returns(mockedCollection.Object);

            var obj = new APWorkersControlPresenter(mockedView.Object, mockedService.Object);

            mockedView.Raise(x => x.GetWorkersNamesAndId += null, EventArgs.Empty);

            Assert.AreSame(mockedCollection.Object, mockedModel.Object.WorkersNamesAndId);
        }
    }
}
