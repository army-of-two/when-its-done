namespace WhenItsDone.Models.Contracts
{
    public interface IIngredient : IDbModel
    {
        int FoodId { get; set; }

        IFood Food { get; set; }

        decimal Quantity { get; set; }
    }
}
