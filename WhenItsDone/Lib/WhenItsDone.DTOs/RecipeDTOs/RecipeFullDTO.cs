using System.Collections.Generic;
using WhenItsDone.DTOs.IngredientDTOs;

namespace WhenItsDone.DTOs.RecipeDTOs
{
    public class RecipeFullDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public virtual ICollection<IngredientWithFoodIdAndNameDTO> Ingredients { get; set; }

        public bool IsDeleted { get; set; }
    }
}
