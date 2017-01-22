using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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

        [Test]
        public void Jobs_ShouldBe_Virtual()
        {
            var obj = new Worker();

            var result = obj.GetType()
                            .GetProperty("Jobs")
                            .GetAccessors()
                            .Where(x => x.IsVirtual)
                            .Any();

            Assert.IsTrue(result);
        }
    }
}
