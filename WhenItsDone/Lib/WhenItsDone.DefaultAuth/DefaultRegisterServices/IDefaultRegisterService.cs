using System;

namespace WhenItsDone.DefaultAuth.DefaultRegisterServices
{
    public interface IDefaultRegisterService
    {
        event EventHandler<DefaultRegisterCompleteOperationEventArgs> OperationComplete;

        void OnDefaultRegister(object sender, DefaultRegisterEventArgs args);
    }
}
