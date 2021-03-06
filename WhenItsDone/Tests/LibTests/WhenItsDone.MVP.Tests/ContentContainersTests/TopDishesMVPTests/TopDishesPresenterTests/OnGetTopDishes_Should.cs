﻿using System;

using Moq;
using NUnit.Framework;

using WhenItsDone.MVP.ContentContainers.TopDishesMVP;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.Tests.ContentContainersTests.TopDishesMVPTests.TopDishesPresenterTests
{
    [TestFixture]
    public class OnGetTopDishes_Should
    {
        [TestCase(-1)]
        [TestCase(-42)]
        [TestCase(int.MinValue)]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenTopDishesEventArgsDishesCountPropertyIsNegative(int invalidDishesCount)
        {
            var topDishesView = new Mock<ITopDishesView>();
            var dishesService = new Mock<IDishesAsyncService>();

            var topDishesPresenter = new TopDishesPresenter(topDishesView.Object, dishesService.Object);

            var topDishesEventArgs = new TopDishesEventArgs(invalidDishesCount, true);
            Assert.That(
                () => topDishesPresenter.OnGetTopDishes(null, topDishesEventArgs),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("dishesCount parameter must be greater than or equal to 0."));
        }

        [Test]
        public void InvokeIDishesAsyncService_GetTopCountDishesByRatingMethodOnce()
        {
            var topDishesView = new Mock<ITopDishesView>();
            topDishesView.SetupGet(view => view.Model).Returns(new TopDishesViewModel());

            var dishesService = new Mock<IDishesAsyncService>();

            var topDishesPresenter = new TopDishesPresenter(topDishesView.Object, dishesService.Object);

            var topDishesEventArgs = new TopDishesEventArgs(3, true);
            topDishesPresenter.OnGetTopDishes(null, topDishesEventArgs);

            dishesService.Verify(service => service.GetTopCountDishesByRating(It.IsAny<int>(), It.IsAny<bool>()), Times.Once);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(42)]
        [TestCase(int.MaxValue)]
        public void InvokeIDishesAsyncService_GetTopCountDishesByRatingMethodOnceWithCorrectDishesCountValue(int dishesCount)
        {
            var topDishesView = new Mock<ITopDishesView>();
            topDishesView.SetupGet(view => view.Model).Returns(new TopDishesViewModel());

            var dishesService = new Mock<IDishesAsyncService>();

            var topDishesPresenter = new TopDishesPresenter(topDishesView.Object, dishesService.Object);

            var topDishesEventArgs = new TopDishesEventArgs(dishesCount, true);
            topDishesPresenter.OnGetTopDishes(null, topDishesEventArgs);

            dishesService.Verify(service => service.GetTopCountDishesByRating(dishesCount, It.IsAny<bool>()), Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void InvokeIDishesAsyncService_GetTopCountDishesByRatingMethodOnceWithCorrectAddSampleDataValue(bool addSampleData)
        {
            var topDishesView = new Mock<ITopDishesView>();
            topDishesView.SetupGet(view => view.Model).Returns(new TopDishesViewModel());

            var dishesService = new Mock<IDishesAsyncService>();

            var topDishesPresenter = new TopDishesPresenter(topDishesView.Object, dishesService.Object);

            var topDishesEventArgs = new TopDishesEventArgs(3, addSampleData);
            topDishesPresenter.OnGetTopDishes(null, topDishesEventArgs);

            dishesService.Verify(service => service.GetTopCountDishesByRating(It.IsAny<int>(), addSampleData), Times.Once);
        }
    }
}
