using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhenItsDone.DTOs.DishViewsDTOs
{
    public class DishBasicsInfoDTO
    {
        public int Id { get; set; }
        
        public int Rating { get; set; }

        public int RecipeId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
