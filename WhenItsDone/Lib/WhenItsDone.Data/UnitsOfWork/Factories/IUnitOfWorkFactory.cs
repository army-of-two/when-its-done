using WhenItsDone.Data.Contracts;

namespace WhenItsDone.Data.UnitsOfWork.Factories
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
