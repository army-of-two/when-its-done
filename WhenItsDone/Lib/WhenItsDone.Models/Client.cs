using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WhenItsDone.Common.Enums;
using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Client : IDbModel
    {
        private ICollection<Job> jobs;
        private ICollection<Payment> payments;

        public Client()
        {
            this.jobs = new HashSet<Job>();
            this.payments = new HashSet<Payment>();

            this.IsAvailable = true;
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

        public GenderType Gender { get; set; }

        [Range(ValidationConstants.AgeMinValue, ValidationConstants.AgeMaxValue)]
        public int Age { get; set; }

        public bool IsAvailable { get; set; }

        [Range(ValidationConstants.RatingMinValue, ValidationConstants.RatingMaxValue)]
        public int Rating { get; set; }

        public int ContactInformationId { get; set; }

        public virtual ContactInformation ContactInformation { get; set; }

        public virtual ICollection<Payment> Payments
        {
            get
            {
                return this.payments;
            }

            set
            {
                this.payments = value;
            }
        }

        public virtual ICollection<Job> Jobs
        {
            get
            {
                return this.jobs;
            }

            set
            {
                this.jobs = value;
            }
        }

        public bool IsDeleted { get; set; }
    }
}
