namespace WhenItsDone.Models.Factories
{
    public interface IInitializedDishFactory
    {
        Dish GetInitializedDish(string name, string price, string calories, string carbohydrates, string fats, string protein, string video);
    }
}
