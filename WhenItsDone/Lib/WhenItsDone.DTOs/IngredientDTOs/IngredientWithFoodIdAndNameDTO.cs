using WhenItsDone.Common.Enums;

namespace WhenItsDone.DTOs.IngredientDTOs
{
    public class IngredientWithFoodIdAndNameDTO
    {
        public int Id { get; set; }

        public int FoodId { get; set; }

        public string Food { get; set; }

        public MeasurementUnitType MeasurementUnitType { get; set; }

        public decimal Quantity { get; set; }
    }
}
