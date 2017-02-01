﻿using Ninject.Modules;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Web.Common;

using WhenItsDone.Data;
using WhenItsDone.Data.AssemblyId;
using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Factories;
using WhenItsDone.Data.Repositories;
using WhenItsDone.Data.UnitsOfWork.Factories;
using WhenItsDone.Data.UnitsOfWork;

using WhenItsDone.Models;
using WhenItsDone.Services;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IDataAssemblyId>()
                .SelectAllClasses()
                .BindDefaultInterface()
            );

            this.Bind<IDisposableUnitOfWork>().To<UnitOfWork>();

            this.Bind<IDisposableUnitOfWorkFactory>()
                .ToFactory()
                .InRequestScope();

            this.Bind(typeof(IAsyncRepository<>))
                .To<GenericAsyncRepository<Worker>>()
                .WhenInjectedInto<WorkersAsyncService>()
                .InRequestScope();

            this.Rebind<IWhenItsDoneDbContext>()
                .To<WhenItsDoneDbContext>()
                .InRequestScope();

            this.Bind<IStatefulFactory>().ToFactory().InSingletonScope();
        }
    }
}