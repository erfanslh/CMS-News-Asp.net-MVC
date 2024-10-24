using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication3.App_Start;
using WebBundleConfig.App_Start;

namespace CMSNachricht
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfig.ConfigureMapping();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
