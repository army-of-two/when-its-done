using NUnit.Framework;
using System.Linq;

namespace WhenItsDone.Models.Tests.VideoItemTests
{
    [TestFixture]
    public class VideoItemTestingTest
    {
        /// <summary>
        /// At that moment VideoItem class have 3 tested properties .. if another property is added this test will fail
        /// That mean new tests are REQUIRED!
        /// </summary>
        [Test]
        public void VideoItem_VerifyNumberOfProperties()
        {
            var obj = new VideoItem();

            var result = obj.GetType()
                            .GetProperties()
                            .Count();

            Assert.AreEqual(3, result);
        }

        /// <summary>
        /// At that moment VideoItem class have 1 tested constructor
        /// </summary>
        [Test]
        public void VideoItem_VerifyNumberOfConstructors()
        {
            var obj = new VideoItem();

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
        /// At that moment VideoItem class have 0 tested methods
        /// </summary>
        [Test]
        public void VideoItem_VerifyNumberOfMethods()
        {
            var methodsFromFramework = 4;
            var expectedMethodsCount = 0;
            var totalMethodsCount = methodsFromFramework + expectedMethodsCount;

            var obj = new VideoItem();

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
        public void VideoItemAsDbModelTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new VideoItemAsDbModelTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void VideoItemAsDbModelTests_VeryfyTestCaseAttributes()
        {
            var obj = new VideoItemAsDbModelTests();

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
        public void VideoItemConstructorTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 4;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new VideoItemConstructorTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 0 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void VideoItemConstructorTests_VeryfyTestCaseAttributes()
        {
            var obj = new VideoItemConstructorTests();

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
        public void VideoItemIdTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 2;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new VideoItemIdTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void VideoItemIdTests_VeryfyTestCaseAttributes()
        {
            var obj = new VideoItemIdTests();

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
        public void VideoItemIsDeletedTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 1;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new VideoItemIsDeletedTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void VideoItemIsDeletedTests_VeryfyTestCaseAttributes()
        {
            var obj = new VideoItemIsDeletedTests();

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
        public void VideoItemUrlTests_VerifyNumberOfTests()
        {
            var methodsFromFramework = 4;
            var expectedMethods = 6;
            var totalExpectedMethods = methodsFromFramework + expectedMethods;

            var obj = new VideoItemUrlTests();

            var result = obj.GetType()
                            .GetMethods()
                            .Count();

            Assert.AreEqual(totalExpectedMethods, result);
        }

        /// <summary>
        /// At that moment TestClass contains 2 TestCase attributes - fail mean someone changed it
        /// </summary>
        [Test]
        public void VideoItemUrlTests_VeryfyTestCaseAttributes()
        {
            var obj = new VideoItemUrlTests();

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
