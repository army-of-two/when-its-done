using System;

using WebFormsMvp;

namespace WhenItsDone.WebFormsClient.App_Start.Factories
{
    public interface ICustomPresenterFactory
    {
        IPresenter CreatePresenter(Type presenterType, Type viewType, IView viewInstance);
    }
}
