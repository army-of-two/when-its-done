using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    // https://en.wikipedia.org/wiki/Bust/waist/hip_measurements
    // Bust/waist/hip measurements a.k.a. vital statistics ( according to wikipedia ) rename to MedicalInformation
    public class MedicalInformation : IDbModel
    {
        private ICollection<User> users;

        public MedicalInformation()
        {
            this.users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Range(ValidationConstants.BustSizeMinValue, ValidationConstants.BustSizeMaxValue)]
        public int? BustSizeInCm { get; set; }

        [Range(ValidationConstants.WaistSizeMinValue, ValidationConstants.WaistSizeMaxValue)]
        public int? WaistSizeInCm { get; set; }

        [Range(ValidationConstants.HipSizeMinValue, ValidationConstants.HipSizeMaxValue)]
        public int? HipSizeInCm { get; set; }

        [Range(ValidationConstants.HeightMinValue, ValidationConstants.HeightMaxValue)]
        public int? HeightInCm { get; set; }

        [Range(ValidationConstants.WeightMinValue, ValidationConstants.WeightMaxValue)]
        public int? WeightInKg { get; set; }

        public int BMI { get; set; }

        public virtual ICollection<User> Users
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }

        public bool IsDeleted { get; set; }
    }
}
