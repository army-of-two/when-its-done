using System.Data.Entity.Infrastructure;
using WhenItsDone.Data.Contracts;

namespace WhenItsDone.Data.Factories
{
    public interface IStatefulFactory
    {
        IStateful<T> CreateStateful<T>(DbEntityEntry<T> entry) where T : class;
    }
}
