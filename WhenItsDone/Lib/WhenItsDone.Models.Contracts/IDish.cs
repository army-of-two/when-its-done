using System.Collections.Generic;

namespace WhenItsDone.Models.Contracts
{
    public interface IDish : IDbModel
    {
        int Rating { get; set; }

        int RecipeId { get; set; }

        IRecipe Recipe { get; set; }

        decimal Price { get; set; }

        ICollection<IPhotoItem> PhotoItems { get; set; }
    }
}
