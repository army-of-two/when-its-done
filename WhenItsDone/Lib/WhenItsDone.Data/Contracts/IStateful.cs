using System.Data.Entity;

namespace WhenItsDone.Data.Contracts
{
    public interface IStateful<T>
    {
        EntityState State { get; set; }
    }
}
