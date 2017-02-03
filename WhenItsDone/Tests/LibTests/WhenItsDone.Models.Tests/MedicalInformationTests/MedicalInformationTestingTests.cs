using NUnit.Framework;
using System.Linq;

namespace WhenItsDone.Models.Tests.MedicalInformationTests
{
    [TestFixture]
    public class MedicalInformationTestingTests
    {
        /// <summary>
        /// At that moment MedicalInformation class have 5 tested properties .. if another property is added this test will fail
        /// That mean new tests are REQUIRED!
        /// </summary>
        [Test]
        public void MedicalInformation_VerifyNumberOfProperties()
        {
            var obj = new MedicalInformation();

            var result = obj.GetType()
                            .GetProperties()
                            .Count();

            Assert.AreEqual(5, result);
        }

        /// <summary>
        /// At that moment MedicalInformation class have 1 tested constructor
        /// </summary>
        [Test]
        public void MedicalInformation_VerifyNumberOfConstructors()
        {
            var obj = new MedicalInformation();

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
        /// At that moment MedicalInformation class have 0 tested methods
        /// </summary>
        [Test]
        public void MedicalInformation_VerifyNumberOfMethods()
        {
            var methodsFromFramework = 4;
            var expectedMethodsCount = 0;
            var totalMethodsCount = methodsFromFramework + expectedMethodsCount;

            var obj = new MedicalInformation();

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
        /// At that moment TestClas contain 2 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void MedicalInformationIdTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 2;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new MedicalInformationIdTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void MedicalInformationIdTests_VeryfyTestCaseAttributes()
        {
            var obj = new MedicalInformationIdTests();

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
        public void MedicalInformationIsDeletedTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new MedicalInformationIsDeletedTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void MedicalInformationIsDeletedTests_VeryfyTestCaseAttributes()
        {
            var obj = new MedicalInformationIsDeletedTests();

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
        public void MedicalInformationAsDbModelTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new MedicalInformationAsDbModelTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void MedicalInformationAsDbModelTests_VeryfyTestCaseAttributes()
        {
            var obj = new MedicalInformationAsDbModelTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// At that moment TestClas contain 6 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void MedicalInformationConstructorTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 6;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new MedicalInformationConstructorTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void MedicalInformationConstructorTests_VeryfyTestCaseAttributes()
        {
            var obj = new MedicalInformationConstructorTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// At that moment TestClas contain 4 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void MedicalInformationBustSizeInCmTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 4;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new MedicalInformationBustSizeInCmTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void MedicalInformationBustSizeInCmTests_VeryfyTestCaseAttributes()
        {
            var obj = new MedicalInformationBustSizeInCmTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(2, result);
        }

        /// <summary>
        /// At that moment TestClas contain 4 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void MedicalInformationHipSizeInCmTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 4;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new MedicalInformationHipSizeInCmTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void MedicalInformationHipSizeInCmTests_VeryfyTestCaseAttributes()
        {
            var obj = new MedicalInformationHipSizeInCmTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(2, result);
        }

        /// <summary>
        /// At that moment TestClas contain 4 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void MedicalInformationWaistSizeInCmTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 4;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new MedicalInformationWaistSizeInCmTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void MedicalInformationWaistSizeInCmTests_VeryfyTestCaseAttributes()
        {
            var obj = new MedicalInformationWaistSizeInCmTests();

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
