using System;
using System.IO;
using System.Linq;

using Bytes2you.Validation;

using WhenItsDone.Common.Providers.FileDownloadProviders.Contracts;
using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.DTOs.UserViewsDTOs;
using WhenItsDone.Models;
using WhenItsDone.Models.Factories;
using WhenItsDone.Services.Abstraction;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.Services
{
    public class UsersAsyncService : GenericAsyncService<User>, IUsersAsyncService, IGenericAsyncService<User>
    {
        private readonly IUsersAsyncRepository asyncRepository;
        private readonly IFileDownloadProvider fileDownloadProvider;
        private readonly IProfilePictureFactory profilePictureFactory;
        private readonly IAddressFactory addressFactory;

        public UsersAsyncService(IUsersAsyncRepository asyncRepository, IDisposableUnitOfWorkFactory unitOfWorkFactory, IFileDownloadProvider fileDownloadProvider, IProfilePictureFactory profilePictureFactory, IAddressFactory addressFactory)
            : base(asyncRepository, unitOfWorkFactory)
        {
            Guard.WhenArgument(asyncRepository, nameof(IUsersAsyncRepository)).IsNull().Throw();
            Guard.WhenArgument(fileDownloadProvider, nameof(IFileDownloadProvider)).IsNull().Throw();
            Guard.WhenArgument(profilePictureFactory, nameof(IProfilePictureFactory)).IsNull().Throw();
            Guard.WhenArgument(addressFactory, nameof(IAddressFactory)).IsNull().Throw();

            this.asyncRepository = asyncRepository;
            this.fileDownloadProvider = fileDownloadProvider;
            this.profilePictureFactory = profilePictureFactory;
            this.addressFactory = addressFactory;
        }

        public UsernameProfilePictureUserViewDTO GetCurrentUserProfilePicture(string username)
        {
            Guard.WhenArgument(username, nameof(username)).IsNullOrEmpty().Throw();

            return this.asyncRepository.GetCurrentUserProfilePicture(username);
        }

        public User UpdateUserProfilePicture(string username, string uploadedFileName, byte[] uploadedFile)
        {
            Guard.WhenArgument(username, nameof(username)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(uploadedFileName, nameof(uploadedFileName)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(uploadedFile, nameof(uploadedFile)).IsNull().Throw();

            var foundUser = this.asyncRepository.GetAll(user => user.Username == username).Result.FirstOrDefault();
            if (foundUser == null)
            {
                throw new ArgumentException(string.Format("User {0} could not be found.", username));
            }

            var updatedProfilePicture = this.profilePictureFactory.CreateProfilePicture();
            updatedProfilePicture.PictureBase64 = Convert.ToBase64String(uploadedFile);
            updatedProfilePicture.MimeType = Path.GetExtension(uploadedFileName).TrimStart(new[] { '.' });

            foundUser.ProfilePicture = updatedProfilePicture;

            return this.SaveChangesToDatabase(foundUser);
        }

        public User UpdateUserProfilePictureFromUrl(string username, string profilePictureUrl)
        {
            Guard.WhenArgument(username, nameof(username)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(profilePictureUrl, nameof(profilePictureUrl)).IsNullOrEmpty().Throw();

            var foundUser = this.asyncRepository.GetAll(user => user.Username == username).Result.FirstOrDefault();
            if (foundUser == null)
            {
                throw new ArgumentException(string.Format("User {0} could not be found.", username));
            }

            var updatedProfilePicture = this.profilePictureFactory.CreateProfilePicture();
            updatedProfilePicture.PictureBase64 = this.fileDownloadProvider.DownloadFileFromUrlToBase64(profilePictureUrl);
            updatedProfilePicture.MimeType = profilePictureUrl.Split('.').Last();

            foundUser.ProfilePicture = updatedProfilePicture;

            return this.SaveChangesToDatabase(foundUser);
        }

        public MedicalInformationUserViewDTO GetCurrentUserMedicalInformation(string username)
        {
            Guard.WhenArgument(username, nameof(username)).IsNullOrEmpty().Throw();

            return this.asyncRepository.GetCurrentUserMedicalInformation(username);
        }

        public User UpdateUserMedicalInformationFromUserInput(string username, string heightInCm, string weightInKg)
        {
            Guard.WhenArgument(username, nameof(username)).IsNullOrEmpty().Throw();

            var foundUser = this.asyncRepository.GetCurrentUserIncludingMedicalInformation(username);
            if (foundUser == null)
            {
                throw new ArgumentException(string.Format("User {0} could not be found.", username));
            }

            int heightInCmParsedValue;
            if (int.TryParse(heightInCm, out heightInCmParsedValue))
            {
                foundUser.MedicalInformation.HeightInCm = heightInCmParsedValue;
            }

            int weightInKgParsedValue;
            if (int.TryParse(weightInKg, out weightInKgParsedValue))
            {
                foundUser.MedicalInformation.WeightInKg = weightInKgParsedValue;
            }

            if (foundUser.MedicalInformation.HeightInCm.HasValue && foundUser.MedicalInformation.WeightInKg.HasValue)
            {
                foundUser.MedicalInformation.BMI = (int)(foundUser.MedicalInformation.WeightInKg / foundUser.MedicalInformation.HeightInCm * foundUser.MedicalInformation.HeightInCm);
            }

            return this.SaveChangesToDatabase(foundUser);
        }

        public ContactInformationUserViewDTO GetCurrentUserContactInformation(string username)
        {
            Guard.WhenArgument(username, nameof(username)).IsNullOrEmpty().Throw();

            return this.asyncRepository.GetCurrentUserContactInformation(username);
        }

        public User UpdateUserContactInformationFromUserInput(string username, string country, string city, string street)
        {
            Guard.WhenArgument(username, nameof(username)).IsNullOrEmpty().Throw();

            var foundUser = this.asyncRepository.GetCurrentUserIncludingContactInformation(username);
            if (foundUser == null)
            {
                throw new ArgumentException(string.Format("User {0} could not be found.", username));
            }

            if (foundUser.ContactInformation.Address == null)
            {
                foundUser.ContactInformation.Address = this.addressFactory.CreateAddress();
            }

            return this.SaveChangesToDatabase(foundUser);
        }

        private User SaveChangesToDatabase(User user)
        {
            this.asyncRepository.Update(user);
            using (var unitOfWork = base.UnitOfWorkFactory.CreateUnitOfWork())
            {
                if (unitOfWork.SaveChangesAsync().Result != 0)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentException("Could not update medical information");
                }
            }
        }
    }
}
