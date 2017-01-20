using Ninject.Modules;
using Ninject.Web.Common;

using WhenItsDone.Services;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class ServicesBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<WorkersDataService>().ToSelf().InRequestScope();
        }
    }
}