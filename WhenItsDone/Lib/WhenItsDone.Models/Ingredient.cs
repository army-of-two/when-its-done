using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        public int FoodId { get; set; }

        [Required]
        public Food Food { get; set; }

        [Range(ValidationConstants.VitaminQuantityMinValue, ValidationConstants.VitaminQuantityMaxValue)]
        public decimal Quantity { get; set; }
    }
}
