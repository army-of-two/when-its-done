using Ninject.Extensions.Conventions;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using Ninject.Web.Common;

using WhenItsDone.Caching;
using WhenItsDone.Services;
using WhenItsDone.Services.AssemblyId;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<TopDishesCachingInterceptor>().ToSelf().InSingletonScope();

            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IServicesAssemblyId>()
                .SelectAllClasses()
                .InheritedFrom<IService>()
                .BindDefaultInterface()
                .Configure(y => y.InRequestScope())
                .ConfigureFor<DishesAsyncService>(dishesService => dishesService.Intercept().With<TopDishesCachingInterceptor>())
            );
        }
    }
}