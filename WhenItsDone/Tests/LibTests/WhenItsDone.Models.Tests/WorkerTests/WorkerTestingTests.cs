using System.Linq;

using NUnit.Framework;

namespace WhenItsDone.Models.Tests.WorkerTests
{
    [TestFixture]
    public class WorkerTestingTests
    {
        /// <summary>
        /// At that moment Worker class have 17 tested properties .. if another property is added this test will fail
        /// That mean new tests are REQUIRED! 
        /// ( Or "junkata" has figured out how to game the test :P )
        /// </summary>
        [Test]
        public void Worker_VerifyNumberOfProperties()
        {
            var result = typeof(Worker)
                            .GetProperties()
                            .Count();

            Assert.AreEqual(20, result);
        }

        /// <summary>
        /// At that moment Worker class have 1 tested constructor
        /// </summary>
        [Test]
        public void Worker_VerifyNumberOfConstructors()
        {
            var obj = new Worker();

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
        /// At that moment Worker class have 0 tested methods
        /// </summary>
        [Test]
        public void Worker_VerifyNumberOfMethods()
        {
            var methodsFromFramework = 4;
            var expectedMethodsCount = 0;
            var totalMethodsCount = methodsFromFramework + expectedMethodsCount;

            var obj = new Worker();

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
        public void WorkerAsDbModelTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerAsDbModelTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerAsDbModelTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerAsDbModelTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// At that moment TestClas contain 17 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerConstructorTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 17;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerConstructorTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerConstructorTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerConstructorTests();

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
        public void WorkerIdTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 2;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerIdTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerIdTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerIdTests();

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
        public void WorkerIsDeletedTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerIsDeletedTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerIsDeletedTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerIsDeletedTests();

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
        public void WorkerAgeTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 4;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerAgeTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerAgeTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerAgeTests();

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
        public void WorkerContactInformationIdTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerContactInformationIdTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerContactInformationIdTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerContactInformationIdTests();

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
        public void WorkerContactInformationTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 2;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerContactInformationTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerContactInformationTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerContactInformationTests();

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
        public void WorkerFirstNameTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 8;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerFirstNameTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 3 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerFirstNameTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerFirstNameTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(3, result);
        }

        /// <summary>
        /// At that moment TestClas contain 8 Test methods = fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerLastNameTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 8;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerLastNameTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 3 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerLastNameTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerLastNameTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(3, result);
        }

        /// <summary>
        /// At that moment TestClas contain 1 Test method = fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerGenderTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerGenderTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 3 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerGenderTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerGenderTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Select(x => x.GetCustomAttributes(false)
                                        .Where(z => z.GetType() == typeof(TestCaseAttribute))
                                        .Count())
                            .Sum();

            Assert.AreEqual(3, result);
        }

        /// <summary>
        /// At that moment TestClas contain 1 Test method = fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerIsAvailableTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerIsAvailableTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerIsAvailableTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerIsAvailableTests();

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
        public void WorkerJobsTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 2;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerJobsTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerJobsTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerJobsTests();

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
        public void WorkerPhotoItemsTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 2;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerPhotoItemsTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerPhotoItemsTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerPhotoItemsTests();

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
        public void WorkerRatingTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 4;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerRatingTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerRatingTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerRatingTests();

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
        public void WorkerReceivedPaymentsTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 2;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerReceivedPaymentsTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerReceivedPaymentsTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerReceivedPaymentsTests();

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
        public void WorkerVideoItemsTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 2;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerVideoItemsTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerVideoItemsTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerVideoItemsTests();

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
        public void WorkerMedicalInformationIdTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerMedicalInformationIdTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerMedicalInformationIdTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerMedicalInformationIdTests();

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
        public void WorkerMedicalInformationTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 2;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new WorkerMedicalInformationTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void WorkerMedicalInformationTests_VeryfyTestCaseAttributes()
        {
            var obj = new WorkerMedicalInformationTests();

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
