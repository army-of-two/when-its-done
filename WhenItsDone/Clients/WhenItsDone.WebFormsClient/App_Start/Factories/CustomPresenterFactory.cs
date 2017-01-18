using System;

using WebFormsMvp;
using WebFormsMvp.Binder;

namespace WhenItsDone.WebFormsClient.App_Start.Factories
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
            if (presenterType == null)
            {
                throw new ArgumentNullException(nameof(presenterType));
            }

            var presenterInstance = this.presenterFactory.CreatePresenter(presenterType, viewType, viewInstance);

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

        //private IPresenter CreatePresenter(Type presenterType)
        //{
        //    var returnedPresenterInstance = this.ninjectKernel.Get(presenterType);
        //    var presenterInstance = returnedPresenterInstance as IPresenter;
        //    if (presenterInstance == null)
        //    {
        //        throw new ArgumentException("Generated object could not be cast to IPresenter.");
        //    }

        //    return presenterInstance;
        //}

        //private IView CreateView(Type viewType)
        //{
        //    if (viewType == null)
        //    {
        //        throw new ArgumentNullException(nameof(viewType));
        //    }

        //    var returnedViewInstance = this.ninjectKernel.Get(viewType);

        //    var castViewInstance = this.ninjectKernel.Get(viewType) as IView;
        //    if (castViewInstance == null)
        //    {
        //        throw new ArgumentException("Generated object could not be cast to IView.");
        //    }

        //    return castViewInstance;
        //}
    }
}