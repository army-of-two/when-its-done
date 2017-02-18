namespace WhenItsDone.DTOs.DishViewsDTOs
{
    public class DishBrowseViewDTO
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public string PhotoUrl { get; set; }

        public string Name { get; set; }

        public decimal AverageNutritionAmount { get; set; }
    }
}
