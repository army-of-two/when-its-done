using Ninject.Modules;
using Ninject.Web.Common;

using WhenItsDone.Data.EntityDataSourceContainer;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class EntityDataSourceContainerNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEntities>().To<Entities>().InRequestScope();
        }
    }
}