using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenItsDone.Models.Enums;

namespace WhenItsDone.Models
{
    public class Food
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IngredientType IngredientType { get; set; }

        public MeasurementUnitType MeasurementUnitType { get; set; }

        public decimal PricePerUnit { get; set; }

        public int NutritionFactsId { get; set; }

        public virtual NutritionFacts NutritionFacts { get; set; }
    }
}
