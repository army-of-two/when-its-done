using NUnit.Framework;
using System.Collections.Generic;
using WhenItsDone.Common.Enums;

namespace WhenItsDone.Models.Tests.ClientTests
{
    [TestFixture]
    public class ClientConstructorTests
    {
        [Test]
        public void ClientClass_ShouldHave_ParameterlessConstructor()
        {
            var obj = new Client();

            Assert.IsInstanceOf<Client>(obj);
        }

        [Test]
        public void Constructor_ShouldSet_Hashset_ToJobsCollection()
        {
            var obj = new Client();

            var result = obj.Jobs.GetType() == typeof(HashSet<Job>);

            Assert.IsTrue(result);
        }

        [Test]
        public void Constructor_ShouldSet_Hashset_ToPaymentsCollection()
        {
            var obj = new Client();

            var result = obj.Payments.GetType() == typeof(HashSet<Payment>);

            Assert.IsTrue(result);
        }

        [Test]
        public void Constructor_ShouldNotSet_IdProperty()
        {
            var obj = new Client();

            Assert.AreEqual(0, obj.Id);
        }

        [Test]
        public void Constructor_ShouldNotSet_FirstNameProperty()
        {
            var obj = new Client();

            Assert.AreEqual(null, obj.FirstName);
        }

        [Test]
        public void Constructor_ShouldNotSet_LastNameProperty()
        {
            var obj = new Client();

            Assert.AreEqual(null, obj.LastName);
        }

        [Test]
        public void Constructor_ShouldNotSet_AgeProperty()
        {
            var obj = new Client();

            Assert.AreEqual(0, obj.Age);
        }

        [Test]
        public void Constructor_ShouldSet_IsAvailable_ToTrue()
        {
            var obj = new Client();

            Assert.IsTrue(obj.IsAvailable);
        }

        [Test]
        public void Constructor_ShouldNotSet_RatingProperty()
        {
            var obj = new Client();

            Assert.AreEqual(0, obj.Rating);
        }

        [Test]
        public void Constructor_ShouldNotSet_ContactInformationIdProperty()
        {
            var obj = new Client();

            Assert.AreEqual(null, obj.ContactInformationId);
        }

        [Test]
        public void Constructor_ShouldNotSet_ContactInformationProperty()
        {
            var obj = new Client();

            Assert.AreEqual(null, obj.ContactInformation);
        }

        [Test]
        public void Constructor_ShouldNotSet_IsDeletedProperty()
        {
            var obj = new Client();

            Assert.IsFalse(obj.IsDeleted);
        }

        [Test]
        public void Constructor_ShouldNotSet_GenderProperty()
        {
            GenderType expectedDefault = GenderType.Undefined;

            var obj = new Client();

            Assert.AreEqual(expectedDefault, obj.Gender); 
        }
    }
}
