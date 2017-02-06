namespace WhenItsDone.Models.Factories
{
    public interface IUserFactory
    {
        User GetUser();

        User GetUser(string name);
    }
}
