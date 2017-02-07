using System;

namespace WhenItsDone.Models.Factories
{
    public interface IInitializedUserFactory
    {
        User GetInitializedUser(Guid aspUserId, string username);
    }
}
