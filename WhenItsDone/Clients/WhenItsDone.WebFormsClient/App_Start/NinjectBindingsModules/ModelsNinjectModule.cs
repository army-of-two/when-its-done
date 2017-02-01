using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;
using Ninject.Modules;

using WhenItsDone.Models.AssemblyId;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class ModelsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.ConfigureConventionBinding);
        }

        private void ConfigureConventionBinding(IFromSyntax bindingSyntax)
        {
            bindingSyntax
                .FromAssemblyContaining<IModelsAssemblyId>()
                .SelectAllClasses()
                .EndingWith("Factory")
                .BindToFactory()
                .Configure(binding => binding.InSingletonScope());
        }
    }
}