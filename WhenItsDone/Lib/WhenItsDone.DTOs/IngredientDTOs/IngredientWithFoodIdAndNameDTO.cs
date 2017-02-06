namespace WhenItsDone.DTOs.IngredientDTOs
{
    public class IngredientWithFoodIdAndNameDTO
    {
        public int Id { get; set; }

        public int FoodId { get; set; }

        public string Food { get; set; }

        public decimal Quantity { get; set; }

        public bool IsDeleted { get; set; }
    }
}
