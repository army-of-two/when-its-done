using System.Collections.Generic;

namespace WhenItsDone.Models.Contracts
{
    public interface INutritionFacts : IDbModel
    {
        decimal Calories { get; set; }

        decimal Carbohydrates { get; set; }

        decimal Fats { get; set; }

        decimal Protein { get; set; }

        ICollection<IVitamin> Vitamins { get; set; }

        ICollection<IMineral> Minerals { get; set; }
    }
}
