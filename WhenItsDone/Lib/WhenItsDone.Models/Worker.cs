using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Worker : IDbModel
    {
        private ICollection<Job> jobs;

        public Worker()
        {
            this.jobs = new HashSet<Job>();

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

        [Range(ValidationConstants.AgeMinValue, ValidationConstants.AgeMaxValue)]
        public int Age { get; set; }

        public int HeightInCm { get; set; }

        public int WeightInKg { get; set; }

        public int BMI { get; set; }

        public bool IsAvailable { get; set; }

        public int VitalStatisticsId { get; set; }

        public virtual VitalStatistics VitalStatistics { get; set; }

        [Range(ValidationConstants.RatingMinValue, ValidationConstants.RatingMaxValue)]
        public int Rating { get; set; }

        public int ContactInformationId { get; set; }

        public virtual ContactInformation ContactInformation { get; set; }

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
