namespace WhenItsDone.DTOs.DishViewsDTOs
{
    public class DishDetailsViewDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Calories { get; set; }

        public decimal Carbohydrates { get; set; }

        public decimal Fats { get; set; }

        public decimal Protein { get; set; }

        public string VideoYouTubeId { get; set; }

        public string PhotoUrl { get; set; }
    }
}
