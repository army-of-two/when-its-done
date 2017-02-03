using Ninject.Extensions.Conventions;
using Ninject.Modules;

using WhenItsDone.DefaultAuth.AssemblyId;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class DefaultAuthNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IDefaultAuthAssemblyId>()
                .SelectAllClasses()
                .BindDefaultInterface()
            );
        }
    }
}