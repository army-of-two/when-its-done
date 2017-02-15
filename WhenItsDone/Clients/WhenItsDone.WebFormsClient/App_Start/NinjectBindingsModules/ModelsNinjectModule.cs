﻿using System;
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

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class ModelsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.ConfigureFactoriesConventionBinding);

            this.Bind<User>().ToSelf().NamedLikeFactoryMethod((ICompleteUserFactory factory) => factory.GetUser());
            this.Bind<User>().ToMethod(this.GetInitializedUserFactoryMethod)
                .NamedLikeFactoryMethod((IInitializedUserFactory factory) => factory.GetInitializedUser(default(Guid), null));

            this.Bind<Dish>().ToSelf().NamedLikeFactoryMethod((ICompleteDishFactory factory) => factory.GetDish());
            this.Bind<Dish>().ToMethod(this.GetInitializedDishFactoryMethod)
                .NamedLikeFactoryMethod((IInitializedDishFactory factory) => factory.GetInitializedDish(null, default(decimal), default(decimal), default(decimal), default(decimal), default(decimal)));
        }

        private void ConfigureFactoriesConventionBinding(IFromSyntax bindingSyntax)
        {
            bindingSyntax
                .FromAssemblyContaining<IModelsAssemblyId>()
                .SelectAllInterfaces()
                .EndingWith("Factory")
                .BindToFactory()
                .Configure(binding => binding.InSingletonScope());
        }

        private User GetInitializedUserFactoryMethod(IContext context)
        {
            var methodParameters = context.Parameters.ToList();
            var aspUserId = (Guid)methodParameters[0].GetValue(context, null);
            var username = (string)methodParameters[1].GetValue(context, null);

            var completeUserFactory = context.Kernel.Get<ICompleteUserFactory>();
            var nextUser = completeUserFactory.GetUser();
            nextUser.Client = completeUserFactory.CreateClient();
            nextUser.Worker = completeUserFactory.CreateWorker();
            nextUser.MedicalInformation = completeUserFactory.CreateMedicalInformation();
            nextUser.ContactInformation = completeUserFactory.CreateContactInformation();

            nextUser.ContactInformation.Email = username;
            nextUser.AspNetUserId = aspUserId;
            nextUser.Username = username;

            return nextUser;
        }

        private Dish GetInitializedDishFactoryMethod(IContext context)
        {
            return null;
        }
    }
}