using System;
using System.Web;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using AutoMapper;

using Ninject;
using Ninject.Web.Common;

using WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules;
using WhenItsDone.WebFormsClient.App_Start.AutomapperProfiles;

using WebFormsMvp.Binder;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WhenItsDone.WebFormsClient.App_Start.AppCompositionRoot), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WhenItsDone.WebFormsClient.App_Start.AppCompositionRoot), "Stop")]

namespace WhenItsDone.WebFormsClient.App_Start
{
    public static class AppCompositionRoot
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        private static volatile IKernel ninjectKernelInstance;
        private static object syncRoot = new Object();

        /// <summary>
        /// Singleton implementation
        /// https://msdn.microsoft.com/en-us/library/ff650316.aspx
        /// 
        /// Singleton should not be required,
        /// Ninject kernel is guaranteed to be only 
        /// registered once by Ninject itself. (?)
        /// Delete this ? 
        /// </summary>
        private static IKernel NinjectKernelInstance
        {
            get
            {
                return AppCompositionRoot.ninjectKernelInstance;
            }

            set
            {
                if (ninjectKernelInstance == null)
                {
                    lock (syncRoot)
                    {
                        if (ninjectKernelInstance == null)
                        {
                            AppCompositionRoot.ninjectKernelInstance = value;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                AppCompositionRoot.RegisterServices(kernel);
                AppCompositionRoot.RegisterPresenterFactory(kernel);
                AppCompositionRoot.RegisterControllerFactory(kernel);
                AppCompositionRoot.InitializeAutomapperConfig();

                // Make IKernel instance available.
                AppCompositionRoot.NinjectKernelInstance = kernel;

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(new MVPNinjectModule());
            kernel.Load(new DataNinjectModule());
            kernel.Load(new ServicesNinjectModule());
            kernel.Load(new DefaultAuthNinjectModule());
            kernel.Load(new ModelsNinjectModule());
        }

        private static void RegisterPresenterFactory(IKernel kernel)
        {
            var customPresenterFactory = kernel.Get<IPresenterFactory>();
            PresenterBinder.Factory = customPresenterFactory;
        }

        private static void RegisterControllerFactory(IKernel kernel)
        {

        }

        private static void InitializeAutomapperConfig()
        {
            Mapper.Initialize(AppCompositionRoot.AddProfilesToAutomapperConfig);
        }

        private static void AddProfilesToAutomapperConfig(IMapperConfigurationExpression config)
        {
            config.AddProfile(new ModelsProfile());
            config.AddProfile(new DishViewsProfile());
            config.AddProfile(new ContactInformationProfile());
            config.AddProfile(new IngredientProfile());
            config.AddProfile(new PhotoItemProfile());
            config.AddProfile(new RecipeProfile());
            config.AddProfile(new WorkerProfile());
        }
    }
}
