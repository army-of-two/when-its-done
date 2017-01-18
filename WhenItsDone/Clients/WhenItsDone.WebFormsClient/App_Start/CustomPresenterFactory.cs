using System;

using Ninject;

using WebFormsMvp;
using WebFormsMvp.Binder;

namespace WhenItsDone.WebFormsClient.App_Start
{
    public class CustomPresenterFactory : IPresenterFactory
    {
        private readonly IKernel ninjectKernel;

        public CustomPresenterFactory(IKernel ninjectKernel)
        {
            if (ninjectKernel == null)
            {
                throw new ArgumentNullException(nameof(ninjectKernel));
            }

            this.ninjectKernel = ninjectKernel;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            throw new NotImplementedException();
        }

        public void Release(IPresenter presenter)
        {
            throw new NotImplementedException();
        }
    }
}