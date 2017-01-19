using System;
using System.Linq;

using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;

using WebFormsMvp;
using WebFormsMvp.Binder;

using WhenItsDone.WebFormsClient.App_Start.Factories;
using Ninject.Activation;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class MVPBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPresenterFactory>().To<CustomWebFormsMvpPresenterFactory>().InSingletonScope();
            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenter>().ToMethod(this.PresenterFactoryMethod)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null, null));
        }

        private IPresenter PresenterFactoryMethod(IContext ctx)
        {
            var parameters = ctx.Parameters.ToList();

            var requestedType = (Type)parameters[0];
            if (requestedType == null)
            {
                throw new ArgumentNullException("Invalid requested presenter type.");
            }

            var viewType = (Type)parameters[1];
            if (viewType == null)
            {
                throw new ArgumentNullException("Invalid requested view type.");
            }

            var viewInstance = (IView)parameters[2];
            if (viewInstance == null)
            {
                viewInstance = (IView)ctx.Kernel.Get(viewType);
            }

            // Unknown possible parameters for each separate IPresenter
            // Binding the view so Ninject can resolve each of them separately.
            var bindingExists = this.Kernel.GetBindings(viewType).Any();
            if (bindingExists)
            {
                this.Rebind(viewType).ToMethod(context => viewInstance);
            }
            else
            {
                this.Bind(viewType).ToMethod(context => viewInstance);
            }

            return (IPresenter)ctx.Kernel.Get(requestedType);
        }
    }
}