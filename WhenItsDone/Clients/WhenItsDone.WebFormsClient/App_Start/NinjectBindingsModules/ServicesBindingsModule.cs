﻿using Ninject.Modules;
using Ninject.Web.Common;

using WhenItsDone.Models;
using WhenItsDone.Services;
using WhenItsDone.Services.Contracts;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class ServicesBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IGenericAsyncService<Worker>>()
                .To<WorkersDataService>()
                .InRequestScope();
        }
    }
}