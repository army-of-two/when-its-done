namespace WhenItsDone.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        public int FoodId { get; set; }

        public Food Food { get; set; }

        public decimal Quantity { get; set; }
    }
}
