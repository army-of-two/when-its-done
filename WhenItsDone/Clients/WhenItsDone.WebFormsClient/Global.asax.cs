using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

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
        }
    }
}