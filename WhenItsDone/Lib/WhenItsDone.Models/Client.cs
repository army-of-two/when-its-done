using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Client : IDbModel
    {
        public Client()
        {
            this.Jobs = new HashSet<Job>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        [RegularExpression(RegexConstants.EnBgSpaceMinus)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        [RegularExpression(RegexConstants.EnBgSpaceMinus)]
        public string LastName { get; set; }

        [Range(ValidationConstants.AgeMinValue, ValidationConstants.AgeMaxValue)]
        public int Age { get; set; }

        public bool IsAvailable { get; set; }

        [Range(ValidationConstants.RatingMinValue, ValidationConstants.RatingMaxValue)]
        public int Rating { get; set; }

        public int ContactInformationId { get; set; }

        public virtual ContactInformation ContactInformation { get; set; }

        public virtual ICollection<Job> Jobs
        {
            get
            {
                return this.Jobs;
            }

            set
            {
                this.Jobs = value;
            }
        }

        public bool IsDeleted { get; set; }
    }
}
