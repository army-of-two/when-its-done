using System;

using WebFormsMvp;

namespace WhenItsDone.WebFormsClient.App_Start.Factories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, Type viewType, IView viewInstance);
    }
}
