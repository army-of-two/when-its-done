using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

using Ninject;

using WebFormsMvp.Binder;

using WhenItsDone.WebFormsClient.App_Start;

namespace WhenItsDone.WebFormsClient
{
    public class Global : HttpApplication
    {
        // Ninject setup first.
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            this.AttachCustomPresenterFactory();
        }

        private void AttachCustomPresenterFactory()
        {
            var customPresenterFactory = NinjectKernelInstanceProvider.Instance.Get<IPresenterFactory>();
            PresenterBinder.Factory = customPresenterFactory;
        }
    }
}