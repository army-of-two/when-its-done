using System.Collections.Generic;
using WhenItsDone.DTOs.IngredientDTOs;

namespace WhenItsDone.DTOs.RecipeDTOs
{
    public class RecipeWithIngredientsDTO
    {
        public int Id { get; set; }

        public IEnumerable<IngredientWithNamesDTO> Ingradients { get; set; }
    }
}
