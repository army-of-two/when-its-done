﻿using System.ComponentModel.DataAnnotations;
using System.Linq;

using NUnit.Framework;

using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models.Tests.VideoItemTests
{
    [TestFixture]
    public class VideoItemUrlTests
    {
        [Test]
        public void YouTubeUrl_ShouldHave_RequiredAttribute()
        {
            var obj = new VideoItem();

            var result = obj.GetType()
                            .GetProperty("YouTubeUrl")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RequiredAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void YouTubeUrl_ShouldHave_MinLengthAttribute()
        {
            var obj = new VideoItem();

            var result = obj.GetType()
                            .GetProperty("YouTubeUrl")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void YouTubeUrl_ShouldHave_RightMinValueFor_RequiredAttribute()
        {
            var obj = new VideoItem();

            var result = obj.GetType()
                            .GetProperty("YouTubeUrl")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Select(x => (MinLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.UrlLengthMinLength, result.Length);
        }

        [Test]
        public void YouTubeUrl_ShouldHave_MaxLengthAttribute()
        {
            var obj = new VideoItem();

            var result = obj.GetType()
                            .GetProperty("YouTubeUrl")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void YouTubeUrl_ShouldHave_RightMaxValueFor_RequiredAttribute()
        {
            var obj = new VideoItem();

            var result = obj.GetType()
                            .GetProperty("YouTubeUrl")
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Select(x => (MaxLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.UrlLengthMaxValue, result.Length);
        }

        [TestCase("mihciuh,fwec")]
        [TestCase("c32c321 23c123c213c")]
        public void YouTubeUrl_GetAndSetShould_WorkProperly(string randomString)
        {
            var obj = new VideoItem();

            obj.YouTubeUrl = randomString;

            Assert.AreEqual(randomString, obj.YouTubeUrl);
        }
    }
}
