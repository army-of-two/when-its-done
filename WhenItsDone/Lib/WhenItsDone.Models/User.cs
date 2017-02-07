using System;
using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class User : IDbModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public Guid AspNetUserId { get; set; }

        [Range(ValidationConstants.RatingMinValue, ValidationConstants.RatingMaxValue)]
        public int Rating { get; set; }

        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        [RegularExpression(RegexConstants.EnBgSpaceMinus)]
        public string FirstName { get; set; }

        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        [RegularExpression(RegexConstants.EnBgSpaceMinus)]
        public string LastName { get; set; }

        public int Gender { get; set; }

        [Range(ValidationConstants.AgeMinValue, ValidationConstants.AgeMaxValue)]
        public int Age { get; set; }

        public int? ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int? WorkerId { get; set; }

        public virtual Worker Worker { get; set; }

        public int ProfilePictureId { get; set; }

        public virtual ProfilePicture ProfilePicture { get; set; }

        public int? MedicalInformationId { get; set; }

        public virtual MedicalInformation MedicalInformation { get; set; }

        public int? ContactInformationId { get; set; }

        public virtual ContactInformation ContactInformation { get; set; }

        public bool IsDeleted { get; set; }
    }
}
