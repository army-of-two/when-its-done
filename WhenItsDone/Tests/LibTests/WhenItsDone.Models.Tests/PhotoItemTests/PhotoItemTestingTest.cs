using NUnit.Framework;
using System.Linq;

namespace WhenItsDone.Models.Tests.PhotoItemTests
{
    [TestFixture]
    public class PhotoItemTestingTest
    {
        /// <summary>
        /// At that moment PhotoItem class have 3 tested properties .. if another property is added this test will fail
        /// That mean new tests are REQUIRED!
        /// </summary>
        [Test]
        public void PhotoItem_VerifyNumberOfProperties()
        {
            var obj = new PhotoItem();

            var result = obj.GetType()
                            .GetProperties()
                            .Count();

            Assert.AreEqual(5, result);
        }

        /// <summary>
        /// At that moment PhotoItem class have 1 tested constructor
        /// </summary>
        [Test]
        public void PhotoItem_VerifyNumberOfConstructors()
        {
            var obj = new PhotoItem();

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
        /// At that moment PhotoItem class have 0 tested methods
        /// </summary>
        [Test]
        public void PhotoItem_VerifyNumberOfMethods()
        {
            var methodsFromFramework = 4;
            var expectedMethodsCount = 0;
            var totalMethodsCount = methodsFromFramework + expectedMethodsCount;

            var obj = new PhotoItem();

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
        public void PhotoItemAsDbModelTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new PhotoItemAsDbModelTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void PhotoItemAsDbModelTests_VeryfyTestCaseAttributes()
        {
            var obj = new PhotoItemAsDbModelTests();

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
        public void PhotoItemConstructorTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 4;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new PhotoItemConstructorTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void PhotoItemConstructorTests_VeryfyTestCaseAttributes()
        {
            var obj = new PhotoItemConstructorTests();

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
        public void PhotoItemIdTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 2;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new PhotoItemIdTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void PhotoItemIdTests_VeryfyTestCaseAttributes()
        {
            var obj = new PhotoItemIdTests();

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
        public void PhotoItemIsDeletedTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new PhotoItemIsDeletedTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void PhotoItemIsDeletedTests_VeryfyTestCaseAttributes()
        {
            var obj = new PhotoItemIsDeletedTests();

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
        public void PhotoItemUrlTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 6;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new PhotoItemUrlTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void PhotoItemUrlTests_VeryfyTestCaseAttributes()
        {
            var obj = new PhotoItemUrlTests();

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
