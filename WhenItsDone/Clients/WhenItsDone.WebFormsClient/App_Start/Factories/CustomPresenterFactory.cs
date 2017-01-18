using System;

using Ninject;

using WebFormsMvp;
using WebFormsMvp.Binder;

namespace WhenItsDone.WebFormsClient.App_Start.Factories
{
    public class WebFormsMvpPresenterFactory : IPresenterFactory
    {
        private readonly IKernel ninjectKernel;

        public WebFormsMvpPresenterFactory(IKernel ninjectKernel)
        {
            if (ninjectKernel == null)
            {
                throw new ArgumentNullException(nameof(ninjectKernel));
            }

            this.ninjectKernel = ninjectKernel;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            if (presenterType == null)
            {
                throw new ArgumentNullException(nameof(presenterType));
            }

            if (viewInstance == null)
            {
                viewInstance = this.ninjectKernel.Get(viewType) as IView;
            }

            if (viewInstance == null)
            {
                throw new ArgumentException("Could not create View instance.");
            }

            var returnedInstance = this.ninjectKernel.Get(presenterType);
            var presenterInstance = returnedInstance as IPresenter;
            if (presenterInstance == null)
            {
                throw new ArgumentException("Generated object could not be cast to IPresenter.");
            }

            return presenterInstance;
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