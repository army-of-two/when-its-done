using NUnit.Framework;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerBMITests
    {
        [TestCase(1116)]
        [TestCase(435332131)]
        public void BMI_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new Worker();

            obj.BMI = randomNumber;

            Assert.AreEqual(randomNumber, obj.BMI);
        }
    }
}
