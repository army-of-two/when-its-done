using NUnit.Framework;

namespace WhenItsDone.Models.Tests.MedicalInformationTests
{
    [TestFixture]
    public class MedicalInformationConstructorTests
    {
        [Test]
        public void MedicalInformation_ShouldHave_ParameterlessConstructor()
        {
            var obj = new MedicalInformation();

            Assert.IsInstanceOf<MedicalInformation>(obj);
        }

        [Test]
        public void Constructor_ShouldNotSet_IdProperty()
        {
            var obj = new MedicalInformation();

            Assert.AreEqual(0, obj.Id);
        }

        [Test]
        public void Constructor_ShouldNotSet_BustSizeInCmProperty()
        {
            var obj = new MedicalInformation();

            Assert.AreEqual(null, obj.BustSizeInCm);
        }

        [Test]
        public void Constructor_ShouldNotSet_WaistSizeInCmProperty()
        {
            var obj = new MedicalInformation();

            Assert.AreEqual(null, obj.WaistSizeInCm);
        }

        [Test]
        public void Constructor_ShouldNotSet_HipSizeInCmProperty()
        {
            var obj = new MedicalInformation();

            Assert.AreEqual(null, obj.HipSizeInCm);
        }

        [Test]
        public void Constructor_ShouldNotSet_IsDeletedProperty()
        {
            var obj = new MedicalInformation();

            Assert.AreEqual(false, obj.IsDeleted);
        }

        [Test]
        public void Consstructor_ShouldNotSet_HeightInCmProperty()
        {
            var obj = new MedicalInformation();

            Assert.AreEqual(null, obj.HeightInCm);
        }

        [Test]
        public void Consstructor_ShouldNotSet_WeightInKgProperty()
        {
            var obj = new MedicalInformation();

            Assert.AreEqual(null, obj.WeightInKg);
        }

        [Test]
        public void Consstructor_ShouldNotSet_BMIProperty()
        {
            var obj = new MedicalInformation();

            Assert.AreEqual(0, obj.BMI);
        }
    }
}
