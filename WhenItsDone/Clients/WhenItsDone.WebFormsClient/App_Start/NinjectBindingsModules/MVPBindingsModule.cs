using System;
using System.Linq;

using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;

using WebFormsMvp;
using WebFormsMvp.Binder;
using WhenItsDone.WebFormsClient.App_Start.Factories;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class MVPBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPresenter>().ToMethod(ctx =>
            {
                var bindingName = ctx.Parameters.First().GetValue(ctx, null).ToString();
                var parameters = ctx.Parameters.ToList();

                // If view object -> return view object
                // If no object -> create it.
                IView view = null;

                this.Bind(typeof(IView)).ToMethod(context => view);

                return ctx.Kernel.Get<IPresenter>(bindingName);
            })
            .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.CreatePresenter(null, null, null));

            this.Kernel.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();
        }
    }
}