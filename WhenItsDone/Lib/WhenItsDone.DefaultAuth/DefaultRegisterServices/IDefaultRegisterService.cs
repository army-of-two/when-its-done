using System;

namespace WhenItsDone.DefaultAuth.DefaultRegisterServices
{
    public interface IDefaultRegisterService
    {
        event EventHandler<DefaultRegisterOperationCompleteEventArgs> OperationComplete;

        void OnDefaultRegister(object sender, DefaultRegisterEventArgs args);
    }
}
