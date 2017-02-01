using System.Collections.Generic;

namespace WhenItsDone.Models.Contracts
{
    public interface IRecipe : IDbModel
    {
        string Name { get; set; }

        string Description { get; set; }

        ICollection<IIngredient> Ingredients { get; set; }
    }
}
