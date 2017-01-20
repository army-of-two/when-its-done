using System;

namespace WhenItsDone.Data.Contracts
{
    public interface IDisposableUnitOfWork : IUnitOfWork, IDisposable
    {
    }
}
