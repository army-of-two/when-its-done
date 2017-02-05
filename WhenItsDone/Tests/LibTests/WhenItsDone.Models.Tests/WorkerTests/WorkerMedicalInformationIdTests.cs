using NUnit.Framework;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerMedicalInformationIdTests
    {
        [TestCase(123231)]
        [TestCase(-7)]
        public void MedicalInformationId_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Worker();

            obj.MedicalInformationId = randomNumber;

            Assert.AreEqual(randomNumber, obj.MedicalInformationId);
        }
    }
}
