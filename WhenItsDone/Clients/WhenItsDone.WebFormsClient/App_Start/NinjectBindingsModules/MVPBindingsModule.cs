using Ninject.Modules;

using WebFormsMvp.Binder;
using WhenItsDone.WebFormsClient.App_Start.Factories;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class MVPBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();
        }
    }
}