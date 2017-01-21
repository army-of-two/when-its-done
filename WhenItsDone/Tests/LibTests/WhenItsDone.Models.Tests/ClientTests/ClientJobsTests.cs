using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WhenItsDone.Models.Tests.ClientTests
{
    [TestFixture]
    public class ClientJobsTests
    {
        [Test]
        public void Jobs_GetAndSetShould_WorkProperly()
        {
            var mockedCollection = new Mock<ICollection<Job>>();

            var obj = new Client();

            obj.Jobs = mockedCollection.Object;

            Assert.AreSame(mockedCollection.Object, obj.Jobs);
        }

        [Test]
        public void Jobs_ShouldBe_Virtual()
        {
            var obj = new Client();

            var result = obj.GetType()
                            .GetProperty("Jobs")
                            .GetAccessors()
                            .Any(x => x.IsVirtual);

            Assert.IsTrue(result);
        }
    }
}
