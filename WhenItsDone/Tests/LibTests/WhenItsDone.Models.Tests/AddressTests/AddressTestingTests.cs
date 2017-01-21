using NUnit.Framework;
using System.Linq;

namespace WhenItsDone.Models.Tests.AddressTests
{
    /// <summary>
    /// Fail some of this test mean have to make more test or been deleted tests
    /// </summary>
    [TestFixture]
    public class AddressTestingTests
    {
        /// <summary>
        /// At that moment Adress class have 5 tested properties .. if another property is added this test will fail
        /// That mean new tests are REQUIRED!
        /// </summary>
        [Test]
        public void AddressClass_VerifyNumberOfProperties()
        {
            var obj = new Address();

            var result = obj.GetType()
                            .GetProperties()
                            .Count();

            Assert.AreEqual(5, result);
        }

        /// <summary>
        /// At that moment Address class have 1 tested constructor
        /// </summary>
        [Test]
        public void AddressClass_VerifyNumberOfConstructors()
        {
            var obj = new Address();

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
        /// At that moment Address class have 0 tested methods
        /// </summary>
        [Test]
        public void AddressClass_VerifyNumberOfMethods()
        {
            var methodsFromFramework = 4;
            var expectedMethodsCount = 0;
            var totalMethodsCount = methodsFromFramework + expectedMethodsCount;

            var obj = new Address();

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
        /// At that moment TestClass contains 1 test - fail mean someone changed it
        /// </summary>
        [Test]
        public void AddressAsDbModelTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedTestCount = 1;
            var totalExpected = methodsFromFramework + expectedTestCount;

            var obj = new AddressAsDbModelTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpected, result);
        }

        /// <summary>
        /// At that moment TestClass contains 8 tests - fail mean someone changed it
        /// </summary>
        [Test]
        public void AddressCityTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedTestCount = 8;
            var totalExpected = methodsFromFramework + expectedTestCount;

            var obj = new AddressCityTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpected, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void AddressCityTest_VeryfyTestCaseAttributes()
        {
            var obj = new AddressCityTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(2, result);
        }

        /// <summary>
        /// At that moment TestClas contain 6 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void AddressConstructorTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 6;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new AddressConstructorTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void AddressConstructorTest_VeryfyTestCaseAttributes()
        {
            var obj = new AddressConstructorTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// At that moment TestClas contain 8 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void AddressCountryTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 8;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new AddressCountryTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void AddressCountryTest_VeryfyTestCaseAttributes()
        {
            var obj = new AddressCountryTests();

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
        public void AddressIdTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 2;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new AddressIdTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void AddressIdTest_VeryfyTestCaseAttributes()
        {
            var obj = new AddressIdTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(2, result);
        }

        /// <summary>
        /// At that moment TestClas contain 1 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void AddressIsDeletedTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new AddressIsDeletedTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void AddressIsDeletedTest_VeryfyTestCaseAttributes()
        {
            var obj = new AddressIsDeletedTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(2, result);
        }

        /// <summary>
        /// At that moment TestClas contain 8 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void AddressStreetDeletedTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 8;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new AddressStreetTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void AddressStreetTest_VeryfyTestCaseAttributes()
        {
            var obj = new AddressStreetTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(2, result);
        }
    }
}
