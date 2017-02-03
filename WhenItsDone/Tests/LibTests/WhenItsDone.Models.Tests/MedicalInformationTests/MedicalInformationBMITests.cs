using NUnit.Framework;

namespace WhenItsDone.Models.Tests.MedicalInformationTests
{
    [TestFixture]
    public class MedicalInformationBMITests
    {
        [TestCase(1116)]
        [TestCase(435332131)]
        public void BMI_GetAndSetShould_WorkProperly(int randomNumber)
        {
            var obj = new MedicalInformation();

            obj.BMI = randomNumber;

            Assert.AreEqual(randomNumber, obj.BMI);
        }
    }
}
