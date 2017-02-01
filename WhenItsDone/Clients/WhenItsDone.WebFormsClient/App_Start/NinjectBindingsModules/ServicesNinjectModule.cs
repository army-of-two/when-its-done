using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;

using WhenItsDone.Services.AssemblyId;
using WhenItsDone.Services.Contracts;

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
        }
    }
}