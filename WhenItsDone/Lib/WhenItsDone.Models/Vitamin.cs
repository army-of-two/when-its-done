using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Vitamin : IDbModel
    {
        [Key]
        public int Id { get; set; }

        [Range(ValidationConstants.QuantityMinValue, ValidationConstants.QuantityMaxValue)]
        public decimal Quantity { get; set; }

        [Required]
        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        [RegularExpression(RegexConstants.EnBgSpaceMinus)]
        public decimal Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
