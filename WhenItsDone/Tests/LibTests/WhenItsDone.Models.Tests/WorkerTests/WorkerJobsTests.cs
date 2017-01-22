using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerJobsTests
    {
        [Test]
        public void Jobs_GetAndSetShould_WorkProperly()
        {
            var mockedCollection = new Mock<ICollection<Job>>();

            var obj = new Worker();

            obj.Jobs = mockedCollection.Object;

            Assert.AreSame(mockedCollection.Object, obj.Jobs);
        }
    }
}
