using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Ingredient : IDbModel
    {
        [Key]
        public int Id { get; set; }

        public int FoodId { get; set; }

        [Required]
        public Food Food { get; set; }

        [Range(ValidationConstants.QuantityMinValue, ValidationConstants.QuantityMaxValue)]
        public decimal Quantity { get; set; }

        public bool IsDeleted { get; set; }
    }
}
