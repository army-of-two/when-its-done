using Ninject.Modules;

using WhenItsDone.Caching;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class CachingNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<TopDishesCachingInterceptor>().ToSelf().InSingletonScope();
        }
    }
}