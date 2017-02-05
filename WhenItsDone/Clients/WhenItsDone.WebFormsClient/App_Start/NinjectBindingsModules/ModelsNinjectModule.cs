using System.Linq;

using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;
using Ninject.Extensions.Factory;
using Ninject.Modules;

using WhenItsDone.Models;
using WhenItsDone.Models.AssemblyId;
using WhenItsDone.Models.Factories;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class ModelsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.ConfigureFactoriesConventionBinding);
        }

        private void ConfigureFactoriesConventionBinding(IFromSyntax bindingSyntax)
        {
            bindingSyntax
                .FromAssemblyContaining<IModelsAssemblyId>()
                .SelectAllInterfaces()
                .EndingWith("Factory")
                .BindToFactory()
                .Configure(binding => binding.InSingletonScope());

            this.Bind<User>().ToSelf().NamedLikeFactoryMethod((ICompleteUserFactory factory) => factory.GetUser());
            this.Bind<User>().ToMethod(this.GetInitializedUserFactoryMethod).NamedLikeFactoryMethod((IInitializedUserFactory factory) => factory.GetInitializedUser(null));
        }

        private User GetInitializedUserFactoryMethod(IContext context)
        {
            var parameters = context.Parameters.ToList();
            var username = (string)parameters[0].GetValue(context, null);

            var completeUserFactory = context.Kernel.Get<ICompleteUserFactory>();
            var nextUser = completeUserFactory.GetUser();
            nextUser.Client = completeUserFactory.CreateClient();
            nextUser.Worker = completeUserFactory.CreateWorker();
            nextUser.MedicalInformation = completeUserFactory.CreateMedicalInformation();
            nextUser.ContactInformation = completeUserFactory.CreateContactInformation();

            nextUser.ContactInformation.Email = username;
            nextUser.Username = username;

            return nextUser;
        }
    }
}