using NUnit.Framework;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerContactInformationIdTests
    {
        [TestCase(323213)]
        [TestCase(-37)]
        public void ContactInformationId_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Worker();

            obj.ContactInformationId = randomNumber;

            Assert.AreEqual(randomNumber, obj.ContactInformationId);
        }
    }
}
