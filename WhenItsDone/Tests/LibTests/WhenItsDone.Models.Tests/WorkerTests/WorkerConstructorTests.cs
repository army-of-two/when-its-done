using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WhenItsDone.Common.Enums;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerConstructorTests
    {
        [Test]
        public void Worker_ShouldHave_ParameterlessConstructor()
        {
            var obj = new Worker();

            Assert.IsInstanceOf<Worker>(obj);
        }

        [Test]
        public void Constructor_ShouldSetHashSet_ToJobs()
        {
            var obj = new Worker();

            var result = obj.Jobs.GetType() == typeof(HashSet<Job>);

            Assert.IsTrue(result);
        }

        [Test]
        public void Constructor_ShouldSetHashSet_ToPhotoItems()
        {
            var obj = new Worker();

            var result = obj.PhotoItems.GetType() == typeof(HashSet<PhotoItem>);

            Assert.IsTrue(result);
        }

        [Test]
        public void Constructor_ShouldSetHashSet_ToVideoItems()
        {
            var obj = new Worker();

            var result = obj.VideoItems.GetType() == typeof(HashSet<VideoItem>);

            Assert.IsTrue(result);
        }

        [Test]
        public void Constructor_ShouldSetHashSet_ToReceivedPayments()
        {
            var obj = new Worker();

            var result = obj.ReceivedPayments.GetType() == typeof(HashSet<ReceivedPayment>);

            Assert.IsTrue(result);
        }

        [Test]
        public void Constructor_ShouldSet_IsAvailable_True()
        {
            var obj = new Worker();

            Assert.IsTrue(obj.IsAvailable);
        }

        [Test]
        public void Consstructor_ShouldNotSet_IdProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(0, obj.Id);
        }

        [Test]
        public void Consstructor_ShouldNotSet_FirstNameProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(null, obj.FirstName);
        }

        [Test]
        public void Consstructor_ShouldNotSet_LastNameProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(null, obj.LastName);
        }

        [Test]
        public void Consstructor_ShouldNotSet_GenderProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(GenderType.Undefined, obj.Gender);
        }

        [Test]
        public void Consstructor_ShouldNotSet_AgeProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(0, obj.Age);
        }

        [Test]
        public void Consstructor_ShouldNotSet_HeightInCmProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(0, obj.HeightInCm);
        }

        [Test]
        public void Consstructor_ShouldNotSet_WeightInKgProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(0, obj.WeightInKg);
        }

        [Test]
        public void Consstructor_ShouldNotSet_BMIProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(0, obj.BMI);
        }

        [Test]
        public void Consstructor_ShouldNotSet_VitalStatisticsProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(null, obj.VitalStatistics);
        }

        [Test]
        public void Consstructor_ShouldNotSet_RatingProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(0, obj.Rating);
        }

        [Test]
        public void Consstructor_ShouldNotSet_ContactInformationIdProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(null, obj.ContactInformationId);
        }

        [Test]
        public void Consstructor_ShouldNotSet_ContactInformationProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(null, obj.ContactInformation);
        }

        [Test]
        public void Consstructor_ShouldNotSet_IsDeletedProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(false, obj.IsDeleted);
        }

        [Test]
        public void Constructor_ShouldNotSet_VitalStatisticsIdProperty()
        {
            var obj = new Worker();

            Assert.AreEqual(null, obj.VitalStatisticsId);
        }
    }
}
