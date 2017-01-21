using Ninject.Modules;
using Ninject.Extensions.Factory;
using Ninject.Web.Common;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Models;
using WhenItsDone.Data.Repositories;
using WhenItsDone.Services;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Data.UnitsOfWork;
using WhenItsDone.Data;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class DataBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDisposableUnitOfWork>().To<DisposableUnitOfWork>();

            this.Bind<IDisposableUnitOfWorkFactory>()
                .ToFactory()
                .InSingletonScope();

            this.Bind(typeof(IAsyncRepository<>))
                .To<AsyncGenericRepository<Worker>>()
                .WhenInjectedInto<WorkersDataService>()
                .InSingletonScope();

            this.Bind<IWhenItsDoneDbContext>()
                .To<WhenItsDoneDbContext>()
                .InRequestScope();
        }
    }
}