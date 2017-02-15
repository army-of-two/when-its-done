using System;
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
                .NamedLikeFactoryMethod((IInitializedUserFactory factory) => factory.GetInitializedUser(default(Guid), default(string)));

            this.Bind<Dish>().ToSelf().NamedLikeFactoryMethod((ICompleteDishFactory factory) => factory.GetDish());
            this.Bind<Dish>().ToMethod(this.GetInitializedDishFactoryMethod)
                .NamedLikeFactoryMethod((IInitializedDishFactory factory) => factory.GetInitializedDish(null, default(decimal), default(decimal), default(decimal), default(decimal), default(decimal)));

            this.Bind<VideoItem>().ToSelf().NamedLikeFactoryMethod((IVideoItemFactory factory) => factory.GetVideoItem());
            this.Bind<VideoItem>().ToMethod(this.GetInitializedVideoItemFactoryMethod)
                .NamedLikeFactoryMethod((IInitializedVideoItemFactory factory) => factory.GetInitializedVideoItem(default(string)));
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
            var methodParameters = context.Parameters.ToList();
            var name = (string)methodParameters[0].GetValue(context, null);
            var price = (decimal)methodParameters[1].GetValue(context, null);
            var calories = (decimal)methodParameters[2].GetValue(context, null);
            var carbohydrates = (decimal)methodParameters[3].GetValue(context, null);
            var fats = (decimal)methodParameters[4].GetValue(context, null);
            var protein = (decimal)methodParameters[5].GetValue(context, null);

            var completeDishFactory = context.Kernel.Get<ICompleteDishFactory>();
            var nextDish = completeDishFactory.GetDish();
            nextDish.Recipe = completeDishFactory.CreateRecipe();
            nextDish.Recipe.NutritionFacts = completeDishFactory.CreateNutritionFacts();

            nextDish.Price = price;

            nextDish.Recipe.Name = name;

            nextDish.Recipe.NutritionFacts.Calories = calories;
            nextDish.Recipe.NutritionFacts.Carbohydrates = carbohydrates;
            nextDish.Recipe.NutritionFacts.Fats = fats;
            nextDish.Recipe.NutritionFacts.Protein = protein;

            return nextDish;
        }

        private VideoItem GetInitializedVideoItemFactoryMethod(IContext context)
        {
            var methodParameters = context.Parameters.FirstOrDefault();
            var youTubeUrl = (string)methodParameters?.GetValue(context, null);

            var videoItemFactory = context.Kernel.Get<IVideoItemFactory>();
            var nextVideoItem = videoItemFactory.GetVideoItem();

            return null;
        }
    }
}