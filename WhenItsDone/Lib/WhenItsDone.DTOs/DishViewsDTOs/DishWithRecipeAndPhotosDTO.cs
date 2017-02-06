using System.Collections.Generic;
using WhenItsDone.DTOs.PhotoItemDTOs;
using WhenItsDone.DTOs.RecipeDTOs;

namespace WhenItsDone.DTOs.DishViewsDTOs
{
    public class DishWithRecipeAndPhotosDTO
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public virtual RecipeFullDTO Recipe { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<PhotoItemDTO> PhotoItems { get; set; }
    }
}
