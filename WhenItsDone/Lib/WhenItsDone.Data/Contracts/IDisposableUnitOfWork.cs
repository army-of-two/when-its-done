using System;

namespace WhenItsDone.Data.Contracts
{
    public interface IDisposableUnitOfWork : IDisposableUnitOfWork, IDisposable
    {
    }
}
