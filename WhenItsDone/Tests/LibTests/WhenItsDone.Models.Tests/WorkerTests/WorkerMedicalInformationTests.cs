using Moq;
using NUnit.Framework;
using System.Linq;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerMedicalInformationTests
    {
        [Test]
        public void MedicalInformation_GetAndSetShould_WorkProperly()
        {
            var mockedVS = new Mock<MedicalInformation>();

            var obj = new Worker();

            obj.MedicalInformation = mockedVS.Object;

            Assert.AreSame(mockedVS.Object, obj.MedicalInformation);
        }

        [Test]
        public void MedicalInformation_ShouldBe_Virtual()
        {
            var obj = new Worker();

            var result = obj.GetType()
                            .GetProperty("MedicalInformation")
                            .GetAccessors()
                            .Where(x => x.IsVirtual)
                            .Any();

            Assert.IsTrue(result);
        }
    }
}
