using System;

using WebFormsMvp;

namespace WhenItsDone.WebFormsClient.App_Start.PresenterFactories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
