using WhenItsDone.Common.Enums;

namespace WhenItsDone.Models.Contracts
{
    public interface IFood : IDbModel
    {
        string Name { get; set; }

        IngredientType IngredientType { get; set; }

        MeasurementUnitType MeasurementUnitType { get; set; }

        decimal PricePerUnit { get; set; }

        int NutritionFactsId { get; set; }

        INutritionFacts NutritionFacts { get; set; }
    }
}
