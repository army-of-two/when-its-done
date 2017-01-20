using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    // https://en.wikipedia.org/wiki/Bust/waist/hip_measurements
    // Bust/waist/hip measurements a.k.a. vital statistics ( according to wikipedia )
    public class VitalStatistics : IDbModel
    {
        [Key]
        public int Id { get; set; }

        [Range(ValidationConstants.BustSizeMinValue, ValidationConstants.BustSizeMaxValue)]
        public int BustSizeInCm { get; set; }

        [Range(ValidationConstants.WaistSizeMinValue, ValidationConstants.WaistSizeMaxValue)]
        public int WaistSizeInCm { get; set; }

        [Range(ValidationConstants.HipSizeMinValue, ValidationConstants.HipSizeMaxValue)]
        public int HipSizeInCm { get; set; }

        public bool IsDeleted { get; set; }
    }
}
