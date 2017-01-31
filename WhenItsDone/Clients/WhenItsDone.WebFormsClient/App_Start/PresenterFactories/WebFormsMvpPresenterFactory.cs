using System;

using WebFormsMvp;
using WebFormsMvp.Binder;

namespace WhenItsDone.WebFormsClient.App_Start.PresenterFactories
{
    public class WebFormsMvpPresenterFactory : IPresenterFactory
    {
        private readonly ICustomPresenterFactory presenterFactory;

        public WebFormsMvpPresenterFactory(ICustomPresenterFactory presenterFactory)
        {
            if (presenterFactory == null)
            {
                throw new ArgumentNullException(nameof(presenterFactory));
            }

            this.presenterFactory = presenterFactory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            return this.presenterFactory.GetPresenter(presenterType, viewInstance);
        }

        /// <summary>
        /// Ignore this, 
        /// Lifetime managerment delegated to Ninject.
        /// </summary>
        /// <param name="presenter"></param>
        public void Release(IPresenter presenter)
        {
            //var disposablePresenter = presenter as IDisposable;
            //if (disposablePresenter != null)
            //{
            //    disposablePresenter.Dispose();
            //}
        }
    }
}