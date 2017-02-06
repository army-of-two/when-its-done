using NUnit.Framework;
using System.Linq;

namespace WhenItsDone.Models.Tests.ContactInformationTests
{
    [TestFixture]
    class ContactInformationTestingTests
    {
        /// <summary>
        /// At that moment ContactInformation class have 6 tested properties .. if another property is added this test will fail
        /// That mean new tests are REQUIRED!
        /// </summary>
        [Test]
        public void ContactInformation_VerifyNumberOfProperties()
        {
            var obj = new ContactInformation();

            var result = obj.GetType()
                            .GetProperties()
                            .Count();

            Assert.AreEqual(9, result);
        }

        /// <summary>
        /// At that moment ContactInformation class have 1 tested constructor
        /// </summary>
        [Test]
        public void ContactInformation_VerifyNumberOfConstructors()
        {
            var obj = new ContactInformation();

            var methodsCount = obj.GetType()
                                    .GetMethods()
                                    .Count();

            var propertiesCount = obj.GetType()
                                    .GetProperties()
                                    .Count();

            var result = obj.GetType()
                            .GetMembers()
                            .Count();

            result = result - propertiesCount - methodsCount;

            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// At that moment ContactInformation class have 0 tested methods
        /// </summary>
        [Test]
        public void ContactInformation_VerifyNumberOfMethods()
        {
            var methodsFromFramework = 4;
            var expectedMethodsCount = 0;
            var totalMethodsCount = methodsFromFramework + expectedMethodsCount;

            var obj = new ContactInformation();

            var numberOfMethodsComeFromProperties = obj.GetType()
                                                        .GetProperties()
                                                        .Select(x => 2)
                                                        .Sum();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            result = result - numberOfMethodsComeFromProperties;

            Assert.AreEqual(totalMethodsCount, result);
        }

        /// <summary>
        /// At that moment TestClas contain 1 Test method = fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationAddressIdTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new ContactInformationAddressIdTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationAddressIdTests_VeryfyTestCaseAttributes()
        {
            var obj = new ContactInformationAddressIdTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(2, result);
        }

        /// <summary>
        /// At that moment TestClas contain 2 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationAddressTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 2;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new ContactInformationAddressTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationAddressTests_VeryfyTestCaseAttributes()
        {
            var obj = new ContactInformationAddressTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// At that moment TestClas contain 1 Test method = fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationAsDbModelTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new ContactInformationAsDbModelTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationAsDbModelTests_VeryfyTestCaseAttributes()
        {
            var obj = new ContactInformationAsDbModelTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// At that moment TestClas contain 7 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationConstructorTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 7;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new ContactInformationConstructorTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationConstructorTests_VeryfyTestCaseAttributes()
        {
            var obj = new ContactInformationConstructorTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// At that moment TestClas contain 2 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationIdTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 2;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new ContactInformationIdTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationIdTests_VeryfyTestCaseAttributes()
        {
            var obj = new ContactInformationIdTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(2, result);
        }

        /// <summary>
        /// At that moment TestClas contain 1 Test method = fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationIsDeletedTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new ContactInformationIsDeletedTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationIsDeletedTests_VeryfyTestCaseAttributes()
        {
            var obj = new ContactInformationIsDeletedTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(2, result);
        }

        /// <summary>
        /// At that moment TestClas contain 6 Test method = fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationPhoneNumberTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 6;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new ContactInformationPhoneNumberTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationPhoneNumberTests_VeryfyTestCaseAttributes()
        {
            var obj = new ContactInformationPhoneNumberTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// At that moment TestClas contain 6 Test method = fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationEmailTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 6;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new ContactInformationEmailTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void ContactInformationEmailTests_VeryfyTestCaseAttributes()
        {
            var obj = new ContactInformationEmailTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(0, result);
        }
    }
}
