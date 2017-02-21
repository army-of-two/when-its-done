using Moq;
using NUnit.Framework;
using System;
using WhenItsDone.Common.Enums;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using WhenItsDone.MVP.AdminPageControls.APWorkerDetailsControlMVP;
using WhenItsDone.MVP.AdminPageControls.EventArguments;
using WhenItsDone.MVP.Tests.Mocks;
using WhenItsDone.Services.Contracts;
using WhenItsDone.Services.Factories;

namespace WhenItsDone.MVP.Tests.AdminPageControlsTests.APWorkerDetailsControlMVP.APWorkerDetailsPresenterTests
{
    [TestFixture]
    public class View_EditRequest_Should
    {
        [Test]
        public void Throw_ArgumentNulleException_WhenEventArgs_AreNull()
        {
            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();
            var mockedDtoFactory = new Mock<IWorkerDetailInformationDTOFactory>();

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object, mockedDtoFactory.Object);

            Assert.Throws<ArgumentNullException>(() => mockedView.Raise(x => x.EditRequest += null, (WorkerDetailsEventArgs)null));
        }

        [TestCase(42)]
        [TestCase(0)]
        [TestCase(-900)]
        public void PassIdProperly_ToFactory_WhenArgument_IsValid(int randomNumber)
        {
            var mockedArgs = new MockedWorkerDetailsEventArgs();
            mockedArgs.Id = randomNumber;

            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();

            var mockedDtoFactory = new Mock<IWorkerDetailInformationDTOFactory>();
            mockedDtoFactory.Setup(x => x.GetWorkerDetailInformationDTO(randomNumber,
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<GenderType>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>())).Verifiable();

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object, mockedDtoFactory.Object);

            mockedView.Raise(x => x.EditRequest += null, mockedArgs);

            mockedDtoFactory.Verify();
        }

        [TestCase("kjdjhskadhj,l")]
        [TestCase(">D>SA?D>ASA?>D")]
        [TestCase("dsjnkjdnsa")]
        [TestCase("")]
        public void PassFirstNameProperly_ToFactory_WhenArgument_IsValid(string randomString)
        {
            var mockedArgs = new MockedWorkerDetailsEventArgs();
            mockedArgs.FirstName = randomString;

            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();

            var mockedDtoFactory = new Mock<IWorkerDetailInformationDTOFactory>();
            mockedDtoFactory.Setup(x => x.GetWorkerDetailInformationDTO(It.IsAny<int>(),
                                                                        randomString,
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<GenderType>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>())).Verifiable();

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object, mockedDtoFactory.Object);

            mockedView.Raise(x => x.EditRequest += null, mockedArgs);

            mockedDtoFactory.Verify();
        }

        [TestCase("kjdjhskadhj,l")]
        [TestCase(">D>SA?D>ASA?>D")]
        [TestCase("dsjnkjdnsa")]
        [TestCase("")]
        public void PassLastNameProperly_ToFactory_WhenArgument_IsValid(string randomString)
        {
            var mockedArgs = new MockedWorkerDetailsEventArgs();
            mockedArgs.LastName = randomString;

            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();

            var mockedDtoFactory = new Mock<IWorkerDetailInformationDTOFactory>();
            mockedDtoFactory.Setup(x => x.GetWorkerDetailInformationDTO(It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        randomString,
                                                                        It.IsAny<GenderType>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>())).Verifiable();

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object, mockedDtoFactory.Object);

            mockedView.Raise(x => x.EditRequest += null, mockedArgs);

            mockedDtoFactory.Verify();
        }

        [TestCase(GenderType.Female)]
        [TestCase(GenderType.Male)]
        [TestCase(GenderType.Undefined)]
        public void PassGenderProperly_ToFactory_WhenArgument_IsValid(GenderType randomGender)
        {
            var mockedArgs = new MockedWorkerDetailsEventArgs();
            mockedArgs.Gender = randomGender;

            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();

            var mockedDtoFactory = new Mock<IWorkerDetailInformationDTOFactory>();
            mockedDtoFactory.Setup(x => x.GetWorkerDetailInformationDTO(It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        randomGender,
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>())).Verifiable();

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object, mockedDtoFactory.Object);

            mockedView.Raise(x => x.EditRequest += null, mockedArgs);

            mockedDtoFactory.Verify();
        }

        [TestCase(66)]
        [TestCase(15)]
        [TestCase(-901)]
        public void PassAgeProperly_ToFactory_WhenArgument_IsValid(int randomNumber)
        {
            var mockedArgs = new MockedWorkerDetailsEventArgs();
            mockedArgs.Age = randomNumber;

            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();

            var mockedDtoFactory = new Mock<IWorkerDetailInformationDTOFactory>();
            mockedDtoFactory.Setup(x => x.GetWorkerDetailInformationDTO(It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<GenderType>(),
                                                                        randomNumber,
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>())).Verifiable();

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object, mockedDtoFactory.Object);

            mockedView.Raise(x => x.EditRequest += null, mockedArgs);

            mockedDtoFactory.Verify();
        }

        [TestCase(4)]
        [TestCase(11115)]
        [TestCase(-1)]
        public void PassRatingProperly_ToFactory_WhenArgument_IsValid(int randomNumber)
        {
            var mockedArgs = new MockedWorkerDetailsEventArgs();
            mockedArgs.Rating = randomNumber;

            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();

            var mockedDtoFactory = new Mock<IWorkerDetailInformationDTOFactory>();
            mockedDtoFactory.Setup(x => x.GetWorkerDetailInformationDTO(It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<GenderType>(),
                                                                        It.IsAny<int>(),
                                                                        randomNumber,
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>())).Verifiable();

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object, mockedDtoFactory.Object);

            mockedView.Raise(x => x.EditRequest += null, mockedArgs);

            mockedDtoFactory.Verify();
        }

        [TestCase("kjdjhskadhj,l")]
        [TestCase(">D>SA?D>ASA?>D")]
        [TestCase("dsjnkjdnsa")]
        [TestCase("")]
        public void PassEmailProperly_ToFactory_WhenArgument_IsValid(string randomString)
        {
            var mockedArgs = new MockedWorkerDetailsEventArgs();
            mockedArgs.Email = randomString;

            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();

            var mockedDtoFactory = new Mock<IWorkerDetailInformationDTOFactory>();
            mockedDtoFactory.Setup(x => x.GetWorkerDetailInformationDTO(It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<GenderType>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<int>(),
                                                                        randomString,
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>())).Verifiable();

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object, mockedDtoFactory.Object);

            mockedView.Raise(x => x.EditRequest += null, mockedArgs);

            mockedDtoFactory.Verify();
        }

        [TestCase("kjdjhskadhj,l")]
        [TestCase(">D>SA?D>ASA?>D")]
        [TestCase("dsjnkjdnsa")]
        [TestCase("")]
        public void PassPhoneProperly_ToFactory_WhenArgument_IsValid(string randomString)
        {
            var mockedArgs = new MockedWorkerDetailsEventArgs();
            mockedArgs.PhoneNumber = randomString;

            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();

            var mockedDtoFactory = new Mock<IWorkerDetailInformationDTOFactory>();
            mockedDtoFactory.Setup(x => x.GetWorkerDetailInformationDTO(It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<GenderType>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        randomString,
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>())).Verifiable();

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object, mockedDtoFactory.Object);

            mockedView.Raise(x => x.EditRequest += null, mockedArgs);

            mockedDtoFactory.Verify();
        }

        [TestCase("kjdjhskadhj,l")]
        [TestCase(">D>SA?D>ASA?>D")]
        [TestCase("dsjnkjdnsa")]
        [TestCase("")]
        public void PassCountryProperly_ToFactory_WhenArgument_IsValid(string randomString)
        {
            var mockedArgs = new MockedWorkerDetailsEventArgs();
            mockedArgs.Country = randomString;

            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();

            var mockedDtoFactory = new Mock<IWorkerDetailInformationDTOFactory>();
            mockedDtoFactory.Setup(x => x.GetWorkerDetailInformationDTO(It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<GenderType>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        randomString,
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>())).Verifiable();

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object, mockedDtoFactory.Object);

            mockedView.Raise(x => x.EditRequest += null, mockedArgs);

            mockedDtoFactory.Verify();
        }

        [TestCase("kjdjhskadhj,l")]
        [TestCase(">D>SA?D>ASA?>D")]
        [TestCase("dsjnkjdnsa")]
        [TestCase("")]
        public void PassCityProperly_ToFactory_WhenArgument_IsValid(string randomString)
        {
            var mockedArgs = new MockedWorkerDetailsEventArgs();
            mockedArgs.City = randomString;

            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();

            var mockedDtoFactory = new Mock<IWorkerDetailInformationDTOFactory>();
            mockedDtoFactory.Setup(x => x.GetWorkerDetailInformationDTO(It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<GenderType>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        randomString,
                                                                        It.IsAny<string>())).Verifiable();

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object, mockedDtoFactory.Object);

            mockedView.Raise(x => x.EditRequest += null, mockedArgs);

            mockedDtoFactory.Verify();
        }

        [TestCase("kjdjhskadhj,l")]
        [TestCase(">D>SA?D>ASA?>D")]
        [TestCase("dsjnkjdnsa")]
        [TestCase("")]
        public void PassStreetProperly_ToFactory_WhenArgument_IsValid(string randomString)
        {
            var mockedArgs = new MockedWorkerDetailsEventArgs();
            mockedArgs.Street = randomString;

            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();

            var mockedDtoFactory = new Mock<IWorkerDetailInformationDTOFactory>();
            mockedDtoFactory.Setup(x => x.GetWorkerDetailInformationDTO(It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<GenderType>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<int>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        It.IsAny<string>(),
                                                                        randomString)).Verifiable();

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object, mockedDtoFactory.Object);

            mockedView.Raise(x => x.EditRequest += null, mockedArgs);

            mockedDtoFactory.Verify();
        }

        [Test]
        public void CallServiceRightMethod_WithSameWorkerDto_CameFromFactory_WhenArguments_AreValid()
        {
            var mockedWorkerDto = new Mock<WorkerDetailInformationDTO>();
            var mockedArgs = new MockedWorkerDetailsEventArgs();

            var mockedView = new Mock<IAPWorkerDetailsControlView>();
            var mockedService = new Mock<IWorkersAsyncService>();
            mockedService.Setup(x => x.UpdateWorkerDetailInformationDTO(mockedWorkerDto.Object)).Verifiable();

            var mockedDtoFactory = new Mock<IWorkerDetailInformationDTOFactory>();
            mockedDtoFactory.Setup(x => x.GetWorkerDetailInformationDTO(It.IsAny<int>(),
                                                            It.IsAny<string>(),
                                                            It.IsAny<string>(),
                                                            It.IsAny<GenderType>(),
                                                            It.IsAny<int>(),
                                                            It.IsAny<int>(),
                                                            It.IsAny<string>(),
                                                            It.IsAny<string>(),
                                                            It.IsAny<string>(),
                                                            It.IsAny<string>(),
                                                            It.IsAny<string>())).Returns(mockedWorkerDto.Object);

            var obj = new APWorkerDetailsPresenter(mockedView.Object, mockedService.Object, mockedDtoFactory.Object);

            mockedView.Raise(x => x.EditRequest += null, mockedArgs);

            mockedService.Verify();
        }
    }
}
