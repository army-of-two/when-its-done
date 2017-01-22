using System.Data.Entity;

namespace WhenItsDone.Data.Contracts
{
    public interface IStateful
    {
        EntityState State { get; set; }
    }
}
