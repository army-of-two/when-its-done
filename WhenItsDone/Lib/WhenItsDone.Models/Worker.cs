using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using WhenItsDone.Common.Enums;
using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Worker : IDbModel
    {
        private ICollection<Job> jobs;
        private ICollection<PhotoItem> photoItems;
        private ICollection<VideoItem> videoItems;
        private ICollection<ReceivedPayment> receivedPayments;
        private ICollection<Dish> dishes;

        public Worker()
        {
            this.jobs = new HashSet<Job>();
            this.photoItems = new HashSet<PhotoItem>();
            this.videoItems = new HashSet<VideoItem>();
            this.receivedPayments = new HashSet<ReceivedPayment>();
            this.dishes = new HashSet<Dish>();

            this.IsAvailable = true;
        }

        [Key]
        public int Id { get; set; }

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

        public GenderType Gender { get; set; }

        [Range(ValidationConstants.AgeMinValue, ValidationConstants.AgeMaxValue)]
        public int Age { get; set; }

        [Range(ValidationConstants.HeightMinValue, ValidationConstants.HeightMaxValue)]
        public int HeightInCm { get; set; }

        [Range(ValidationConstants.WeightMinValue, ValidationConstants.WeightMaxValue)]
        public int WeightInKg { get; set; }

        public int BMI { get; set; }

        public bool IsAvailable { get; set; }

        public int? VitalStatisticsId { get; set; }

        public virtual MedicalInformation VitalStatistics { get; set; }

        public int? ContactInformationId { get; set; }

        public virtual ContactInformation ContactInformation { get; set; }

        public virtual ICollection<Dish> Dishes
        {
            get
            {
                return this.dishes;
            }

            set
            {
                this.dishes = value;
            }
        }

        public virtual ICollection<ReceivedPayment> ReceivedPayments
        {
            get
            {
                return this.receivedPayments;
            }

            set
            {
                this.receivedPayments = value;
            }
        }

        public virtual ICollection<VideoItem> VideoItems
        {
            get
            {
                return this.videoItems;
            }

            set
            {
                this.videoItems = value;
            }
        }

        public virtual ICollection<PhotoItem> PhotoItems
        {
            get
            {
                return this.photoItems;
            }

            set
            {
                this.photoItems = value;
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
