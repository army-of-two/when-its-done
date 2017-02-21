using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.Services.Factories;

namespace WhenItsDone.Services.Tests.WorkersAsyncServiceTests
{
    [TestFixture]
    public class GetWorkersNamesAndId_Should
    {
        [Test]
        public void Call_ReposGetWorkersNamesAndId_And_ReturnResult()
        {
            var mockedResult = new Mock<IEnumerable<WorkerNamesIdDTO>>();

            var task = Task.FromResult(mockedResult.Object);

            var mockedRepo = new Mock<IWorkerAsyncRepository>();
            mockedRepo.Setup(x => x.GetWorkersNamesAndId()).Returns(task);

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var mockedModelFactory = new Mock<IDbModelFactory>();

            var obj = new WorkersAsyncService(mockedRepo.Object, mockedFactory.Object, mockedModelFactory.Object);

            var result = obj.GetWorkersNamesAndId();

            Assert.AreSame(mockedResult.Object, result);
        }
    }
}
