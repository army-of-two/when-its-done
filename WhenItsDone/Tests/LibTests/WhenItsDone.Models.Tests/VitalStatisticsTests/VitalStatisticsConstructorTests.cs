using NUnit.Framework;

namespace WhenItsDone.Models.Tests.VitalStatisticsTests
{
    [TestFixture]
    public class VitalStatisticsConstructorTests
    {
        [Test]
        public void VitalStatistics_ShouldHave_ParameterlessConstructor()
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

            Assert.AreEqual(0, obj.BustSizeInCm);
        }

        [Test]
        public void Constructor_ShouldNotSet_WaistSizeInCmProperty()
        {
            var obj = new MedicalInformation();

            Assert.AreEqual(0, obj.WaistSizeInCm);
        }

        [Test]
        public void Constructor_ShouldNotSet_HipSizeInCmProperty()
        {
            var obj = new MedicalInformation();

            Assert.AreEqual(0, obj.HipSizeInCm);
        }

        [Test]
        public void Constructor_ShouldNotSet_IsDeletedProperty()
        {
            var obj = new MedicalInformation();

            Assert.AreEqual(false, obj.IsDeleted);
        }
    }
}
