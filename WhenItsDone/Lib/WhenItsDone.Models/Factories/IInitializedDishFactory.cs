namespace WhenItsDone.Models.Factories
{
    public interface IInitializedDishFactory
    {
        Dish GetInitializedDish(string name, string description, decimal price, decimal calories, decimal carbohydrates, decimal fats, decimal protein);
    }
}
