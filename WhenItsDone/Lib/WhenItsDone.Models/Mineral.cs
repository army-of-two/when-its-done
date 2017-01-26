using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models
{
    public class Mineral
    {
        [Key]
        public int Id { get; set; }

        [Range(ValidationConstants.VitaminQuantityMinValue, ValidationConstants.VitaminQuantityMaxValue)]
        public decimal Quantity { get; set; }

        [Required]
        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        [RegularExpression(RegexConstants.EnBgSpaceMinus)]
        public decimal Name { get; set; }
    }
}