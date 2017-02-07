using System.Collections.Generic;
using WhenItsDone.DTOs.IngradientDTOs;

namespace WhenItsDone.DTOs.DishViewsDTOs
{
    public class DishWithIngradientsDTO
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public IEnumerable<IngradientWithNamesDTO> Ingradients { get; set; }
    }
}
