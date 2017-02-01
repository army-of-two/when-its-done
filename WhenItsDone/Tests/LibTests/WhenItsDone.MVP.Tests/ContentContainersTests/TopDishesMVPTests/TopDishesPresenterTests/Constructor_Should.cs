﻿using System;

using Moq;
using NUnit.Framework;

using WhenItsDone.MVP.ContentContainers.TopDishesMVP;
using WhenItsDone.Services.Contracts;

using WebFormsMvp;
using WhenItsDone.MVP.Tests.ContentContainersTests.TopDishesMVPTests.Mocks;

namespace WhenItsDone.MVP.Tests.ContentContainersTests.TopDishesMVPTests.TopDishesPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIDishesAsyncServiceIsNull()
        {
            var topDishesView = new Mock<ITopDishesView>();
            IDishesAsyncService dishesService = null;

            Assert.That(
                () => new TopDishesPresenter(topDishesView.Object, dishesService),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(dishesService)));
        }

        [Test]
        public void CreateAnInstance_WhenParametersAreCorrect()
        {
            var topDishesView = new Mock<ITopDishesView>();
            var dishesService = new Mock<IDishesAsyncService>();

            var actualInstance = new TopDishesPresenter(topDishesView.Object, dishesService.Object);

            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void CreateAnInstanceInheritingPresenter_WhenParametersAreCorrect()
        {
            var topDishesView = new Mock<ITopDishesView>();
            var dishesService = new Mock<IDishesAsyncService>();

            var actualInstance = new TopDishesPresenter(topDishesView.Object, dishesService.Object);

            Assert.That(actualInstance, Is.InstanceOf<Presenter<ITopDishesView>>());
        }

        [Test]
        public void CreateAnInstanceImplementingITopDishesPresenter_WhenParametersAreCorrect()
        {
            var topDishesView = new Mock<ITopDishesView>();
            var dishesService = new Mock<IDishesAsyncService>();

            var actualInstance = new TopDishesPresenter(topDishesView.Object, dishesService.Object);

            Assert.That(actualInstance, Is.InstanceOf<ITopDishesPresenter>());
        }

        [Test]
        public void SubscribeToViewGetTopDishesEvent()
        {
            var topDishesView = new FakeTopDishesView();
            var dishesService = new Mock<IDishesAsyncService>();

            var actualInstance = new TopDishesPresenter(topDishesView, dishesService.Object);
            
            Assert.That(topDishesView.ContainsSubscribedMethod("OnGetTopDishes"), Is.True);
        }
    }
}
