using Ninject.Extensions.Conventions;
using Ninject.Modules;

using WhenItsDone.Data.EntityDataSourceServices.AssemblyId;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class EntityDataSourceServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IEntityDataSourceServicesAssemblyId>()
                .SelectAllClasses()
                .BindDefaultInterface()
            );
        }
    }
}