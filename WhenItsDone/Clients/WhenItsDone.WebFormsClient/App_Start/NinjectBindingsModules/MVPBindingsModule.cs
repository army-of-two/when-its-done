using Ninject.Modules;

using WebFormsMvp.Binder;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class MVPBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IPresenterFactory>().To<CustomPresenterFactory>().InSingletonScope();
        }
    }
}