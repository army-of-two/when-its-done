using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;
using Ninject.Modules;

using WhenItsDone.Common.AssemblyId;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class CommonNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.ConfigureFactoriesConventionBinding);
        }

        private void ConfigureFactoriesConventionBinding(IFromSyntax bindingSyntax)
        {
            bindingSyntax
                .FromAssemblyContaining<ICommonAssemblyId>()
                .SelectAllClasses()
                .BindDefaultInterface();
        }
    }
}