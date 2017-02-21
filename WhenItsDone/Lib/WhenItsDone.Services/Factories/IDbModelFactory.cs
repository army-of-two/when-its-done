using System;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Services.Factories
{
    public interface IDbModelFactory
    {
        T GetEmptyDbModel<T>() where T : IDbModel;
    }
}
