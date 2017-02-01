using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Web.Common;

using WhenItsDone.Services.AssemblyId;
using WhenItsDone.Services.Contracts;
using WhenItsDone.Services.Factories;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IServicesAssemblyId>()
                .SelectAllClasses()
                .InheritedFrom<IService>()
                .BindDefaultInterface()
                .Configure(y => y.InRequestScope())
            );

            this.Bind<IUserFactory>().ToFactory().InSingletonScope();
        }
    }
}