using System;
using System.Reflection;

using NUnit.Framework;
using Moq;

using WebFormsMvp;

using WhenItsDone.MVP.AccountPages.ManageMVP.UploadProfilePictureMVP;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.Tests.AccountPages.ManageMVP.UploadProfilePicturePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArugmentNullException_WhenIUserAsyncServiceParameterIsNull()
        {
            var uploadProfilePictureView = new Mock<IUploadProfilePictureView>();
            IUsersAsyncService usersAsyncService = null;

            Assert.That(
                () => new UploadProfilePicturePresenter(uploadProfilePictureView.Object, usersAsyncService),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(IUsersAsyncService)));
        }

        [Test]
        public void CreateAnInstance_WhenParametersAreCorrect()
        {
            var topDishesView = new Mock<IUploadProfilePictureView>();
            var usersAsyncService = new Mock<IUsersAsyncService>();

            var actualInstance = new UploadProfilePicturePresenter(topDishesView.Object, usersAsyncService.Object);

            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void CreateAnInstanceInheritingPresenter_WhenParametersAreCorrect()
        {
            var topDishesView = new Mock<IUploadProfilePictureView>();
            var usersAsyncService = new Mock<IUsersAsyncService>();

            var actualInstance = new UploadProfilePicturePresenter(topDishesView.Object, usersAsyncService.Object);

            Assert.That(actualInstance, Is.InstanceOf<Presenter<IUploadProfilePictureView>>());
        }

        [Test]
        public void CreateAnInstanceImplementingITopDishesPresenter_WhenParametersAreCorrect()
        {
            var topDishesView = new Mock<IUploadProfilePictureView>();
            var usersAsyncService = new Mock<IUsersAsyncService>();

            var actualInstance = new UploadProfilePicturePresenter(topDishesView.Object, usersAsyncService.Object);

            Assert.That(actualInstance, Is.InstanceOf<IUploadProfilePicturePresenter>());
        }


        [Test]
        public void ShouldSetCorrectValueToIDishesAsyncServiceField()
        {
            var topDishesView = new Mock<IUploadProfilePictureView>();
            var usersAsyncService = new Mock<IUsersAsyncService>();

            var actualInstance = new UploadProfilePicturePresenter(topDishesView.Object, usersAsyncService.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dishesServiceField = typeof(UploadProfilePicturePresenter).GetField("usersService", bindingFlags);
            var dishesServiceFieldValue = dishesServiceField.GetValue(actualInstance);

            Assert.That(dishesServiceFieldValue, Is.Not.Null);
        }
    }
}
