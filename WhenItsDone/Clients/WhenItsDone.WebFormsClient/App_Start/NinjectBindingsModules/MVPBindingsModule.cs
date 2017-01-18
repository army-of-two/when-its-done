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
                var requestedType = (Type)ctx.Parameters.First().GetValue(ctx, null);
                var parameters = ctx.Parameters.ToList();

                if (parameters.Count < 3)
                {
                    throw new ArgumentException("Expected at least 3 parameters.");
                }

                var view = (IView)parameters[2];
                if (view == null)
                {
                    var viewType = (Type)parameters[1];
                    if (viewType == null)
                    {
                        throw new ArgumentNullException("Invalid view type.");
                    }

                    view = (IView)ctx.Kernel.Get(viewType);
                }

                this.Bind(typeof(IView)).ToMethod(context => view);

                return (IPresenter)ctx.Kernel.Get(requestedType);
            })
            .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.CreatePresenter(null, null, null));

            this.Kernel.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();
        }
    }
}