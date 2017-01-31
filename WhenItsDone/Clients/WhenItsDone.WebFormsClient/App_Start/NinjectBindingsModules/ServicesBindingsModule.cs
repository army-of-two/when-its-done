using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;

using WhenItsDone.Models;
using WhenItsDone.Services;
using WhenItsDone.Services.AssemblyId;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class ServicesBindingsModule : NinjectModule
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

            // not sure its still needed
            //this.Bind<IGenericAsyncService<Worker>>()
            //    .To<WorkersAsyncService>()
            //    .InRequestScope();
        }
    }
}