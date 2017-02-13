﻿using Moq;
using NUnit.Framework;
using System;
using System.Reflection;
using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;

namespace WhenItsDone.Services.Tests.WorkersAsyncServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        // no matter base have same test the class keep reference of repo and test should exsist
        [Test]
        public void Throw_ArgumentNullException_WhenRepo_IsNull()
        {
            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            Assert.Throws<ArgumentNullException>(() => new WorkersAsyncService(null, mockedFactory.Object));
        }

        [Test]
        public void Assign_RepoField_WhenParameters_AreCorect()
        {
            var mockedRepo = new Mock<IWorkerAsyncRepository>();

            var mockedFactory = new Mock<IDisposableUnitOfWorkFactory>();

            var obj = new WorkersAsyncService(mockedRepo.Object, mockedFactory.Object);

            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

            var repoField = typeof(WorkersAsyncService)
                                .GetField("workerRepo", bindingFlags)
                                .GetValue(obj);

            Assert.AreSame(mockedRepo.Object, repoField);
        }
    }
}
